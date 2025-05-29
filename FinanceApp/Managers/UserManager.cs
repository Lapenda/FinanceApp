using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IdentityModel.Tokens.Jwt;
using FinanceApp.Models;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using FinanceApp.Properties;

namespace FinanceApp.Managers
{
    internal class UserManager
    {
        private readonly string connectionString;
        private readonly string jwtSecretKey;
        private readonly Dictionary<int, User> users = new Dictionary<int, User>();

        public IReadOnlyCollection<User> GetAllUsers() => users.Values.ToList().AsReadOnly();

        public UserManager()
        {
            connectionString = Environment.GetEnvironmentVariable("FINANCEAPP_CONNECTION_STRING");
            jwtSecretKey = Environment.GetEnvironmentVariable("FINANCEAPP_JWT_SECRET");

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(jwtSecretKey))
            {
                MessageBox.Show("Environment variables FINANCEAPP_CONNECTION_STRING and FINANCEAPP_JWT_SECRET must be set.");
                Application.Exit();
                throw new Exception("Environment variables FINANCEAPP_CONNECTION_STRING and FINANCEAPP_JWT_SECRET must be set.");
            }

            LoadUsersFromDatabase();
        }

        public bool Register(string username, string password, string role)
        {
            int newId = users.Count > 0 ? users.Keys.Max() + 1 : 1;
            var user = new User(newId, username, password, role);

            var existingUser = users.FirstOrDefault(u => u.Value.Username == username);

            if(existingUser.Value != null)
            {
                MessageBox.Show("Username is taken");
                return false;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Users (Username, Password, Role) " +
                    "VALUES (@Username, @Password, @Role)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.ExecuteNonQuery();
                connection.Close();
            }

            users[user.Id] = user;
            return true;
        }

        public string Login(string username, string password)
        {
            var user = users.Values.FirstOrDefault(u => u.Username == username);
            if(user == null || !user.ValidatePepper(password, user.Password))
            {
                MessageBox.Show(Resources.InvalidCredentialsMessage);
                throw new InvalidOperationException("Invalid username or password.");
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal = null;
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSecretKey);
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };

                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Token validation failed: " + ex.Message);
                return false;
            }
        }

        private void LoadUsersFromDatabase()
        {
            using(var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users", connection);
                
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User(
                            reader.GetInt32("Id"),
                            reader.GetString("Username"),
                            reader.GetString("Password"),
                            reader.GetString("Role"),
                            reader.GetDateTime("CreatedAt")
                            );

                        users[user.Id] = user;
                    }
                }
                connection.Close();
            }
        }
    }
}

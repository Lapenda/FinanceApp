using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq;

namespace FinanceApp.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(int id, string username, string password, string role)
        {
            if (id < 0) throw new ArgumentException("User ID cannot be negative.", nameof(id));
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be empty.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));
            if (string.IsNullOrWhiteSpace(role)) throw new ArgumentException("Role cannot be empty.", nameof(role));

            Id = id;
            Username = username;
            Role = role;
            CreatedAt = DateTime.Now;

            Password = HashPassword(password);
        }

        public User(int id, string username, string hashedPassword, string role, DateTime createdAt)
        {
            Id = id;
            Username = username;
            Password = hashedPassword;
            Role = role;
            CreatedAt = createdAt;
        }

        public bool ValidatePepper(string password, string storedHashPass)
        {
            string salt = GenerateSalt();

            string[] possiblePeppers = { "papar1", "papar2,", "mojMaliPapar", "papar3" };

            foreach(var pepper in possiblePeppers)
            {
                string testHash = HashPasswordWithPepper(password + salt, pepper);
                if(testHash == storedHashPass) return true;
            }

            Console.WriteLine("No matching pepper found");
            return false;
        }

        public bool VerifyPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            string hashedInput = HashPassword(password);
            return Password == hashedInput;
        }

        private string HashPassword(string password)
        {
            string salt = GenerateSalt();
            return HashPasswordWithPepper(password + salt, GetPepper());
        }

        private string GenerateSalt()
        {
            var combined = Username + Username.Reverse();
            using(var sha256 = SHA256.Create())
            {
                byte[] saltBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                return Convert.ToBase64String(saltBytes);
            }
        }

        private static string HashPasswordWithPepper(string input, string pepper)
        {
            string saltPepPass = input + pepper;

            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltPepPass));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static string GetPepper()
        {
            return "mojMaliPapar";
        }
    }
}

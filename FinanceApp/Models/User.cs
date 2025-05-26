using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Models
{
    public class User
    {
        private int Id { get; set; }
        private string Username { get; set; }
        private string Role { get; set; }

        public User(int id, string username, string role)
        {
            Id = id;
            Username = username;
            Role = role;
        }

        public bool Login(string username, string password)
        {
            return username == Username && password == "pass123";
        }

        public void Logout()
        {
            MessageBox.Show($"{ Username } logged out!");
        }

        public void SignIn(string username, string password)
        {
           
        }
    }
}

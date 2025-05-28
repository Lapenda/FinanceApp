using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(int id)
        {
            Id = id;
        }

        public Category(int userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }
    }
}

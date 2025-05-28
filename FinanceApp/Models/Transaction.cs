using FinanceApp.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Models
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public float Amount { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public string Currency { get; private set; }
        public DateTime Date { get; private set; }

        public Transaction(int id, int userId, float amount, string description, Category category, string currency, DateTime date)
        {
            if (id < 0) throw new ArgumentException("Transaction ID cannot be negative.", nameof(id));
            if (userId < 0) throw new ArgumentException("User ID cannot be negative.", nameof(userId));
            if (amount < 0) throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (date == default) throw new ArgumentException("Date must be specified.", nameof(date));
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must be set.", nameof(description));

            Id = id;
            UserId = userId;
            Amount = amount;
            Category = category;
            Description = description;
            Date = date;
            Currency = currency;
        }

        public Transaction(int userId, float amount, string description, Category category, string currency, DateTime date)
        {
            if (userId < 0) throw new ArgumentException("User ID cannot be negative.", nameof(userId));
            if (amount < 0) throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (date == default) throw new ArgumentException("Date must be specified.", nameof(date));
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must be set.", nameof(description));

            UserId = userId;
            Amount = amount;
            Category = category;
            Description = description;
            Date = date;
            Currency = currency;
        }
    }
}

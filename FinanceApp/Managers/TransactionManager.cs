using FinanceApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Managers
{
    internal class TransactionManager
    {
        private readonly CategoryManager categoryManager;
        private static readonly Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
        private readonly string connectionString = Environment.GetEnvironmentVariable("FINANCEAPP_CONNECTION_STRING");

        public IReadOnlyCollection<Transaction> GetAllTransactions() => transactions.Values.ToList().AsReadOnly();

        public TransactionManager()
        {
            transactions.Clear();
            categoryManager = new CategoryManager("categories.xml");
            GetTransactionsFromDatabase();
        }

        public void Save(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            using(var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO transactions (UserId, Amount, Description, CategoryId, Currency, TransactionDate) " +
                    "VALUES (@UserId, @Amount, @Description, @CategoryId, @Currency, @TransactionDate)", connection);
                command.Parameters.AddWithValue("@UserId", transaction.UserId);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@Description", transaction.Description);
                command.Parameters.AddWithValue("@CategoryId", transaction.Category.Id);
                command.Parameters.AddWithValue("@Currency", transaction.Currency);
                command.Parameters.AddWithValue("@TransactionDate", transaction.Date);

                command.ExecuteNonQuery();
            }

            GetTransactionsFromDatabase();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (!transactions.Remove(transaction.Id))
                throw new InvalidOperationException($"Transaction with ID {transaction.Id} not found.");


        }

        public void EditTransaction(Transaction updatedTransaction)
        {
            if (updatedTransaction == null) throw new ArgumentNullException(nameof(updatedTransaction));
            if (!transactions.ContainsKey(updatedTransaction.Id))
                throw new InvalidOperationException($"Transaction with ID {updatedTransaction.Id} not found.");

            transactions[updatedTransaction.Id] = updatedTransaction;
        }

        private void GetTransactionsFromDatabase()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM transactions WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", SessionManager.currentUserId);

                var categories = categoryManager.ReadAllUserCategories();

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = categories.First(c => c.Id == reader.GetInt32("CategoryId"));

                        var transaction = new Transaction(
                            reader.GetInt32("Id"),
                            reader.GetInt32("UserId"),
                            reader.GetFloat("Amount"),
                            reader.GetString("Description"),
                            category,
                            reader.GetString("Currency"),
                            reader.GetDateTime("TransactionDate")
                            );

                        transactions[transaction.Id] = transaction;
                    }
                }                
            }
        }
    }
}

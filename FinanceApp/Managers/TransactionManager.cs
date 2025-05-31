using FinanceApp.Forms;
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
            categoryManager = new CategoryManager("categories.xml", this);
            GetTransactionsFromDatabase();
        }

        public void Save(Transaction transaction)
        {
            try
            {
                if (transaction == null) throw new ArgumentNullException(nameof(transaction));

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("INSERT INTO transactions (UserId, Amount, Description, CategoryId, Currency, TransactionDate, ReceiptImage) " +
                        "VALUES (@UserId, @Amount, @Description, @CategoryId, @Currency, @TransactionDate, @ReceiptImage)", connection);
                    command.Parameters.AddWithValue("@UserId", transaction.UserId);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Description", transaction.Description);
                    command.Parameters.AddWithValue("@CategoryId", transaction.Category.Id);
                    command.Parameters.AddWithValue("@Currency", transaction.Currency);
                    command.Parameters.AddWithValue("@TransactionDate", transaction.Date);
                    command.Parameters.AddWithValue("@ReceiptImage", transaction.ReceiptImage ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }

                GetTransactionsFromDatabase();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving transaction to database: " + ex.Message);
            }
        }

        public void DeleteTransaction(Transaction transaction)
        {
            try
            {
                if (transaction == null) throw new ArgumentNullException(nameof(transaction));
                if (!transactions.Remove(transaction.Id))
                    throw new InvalidOperationException($"Transaction with ID {transaction.Id} not found.");

                using(var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new MySqlCommand("DELETE FROM transactions WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", transaction.Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception($"Transaction with Id {transaction.Id} not found or not owned by user.");
                    }

                    BudgetForm budgetForm = new BudgetForm();
                    budgetForm.UpdateBudget(-transaction.Amount, transaction.Category);

                    transactions.Remove(transaction.Id);
                    GetTransactionsFromDatabase();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errror deleting transaction: " + ex.Message);
            }
        }

        public void EditTransaction(Transaction updatedTransaction)
        {
            try
            {
                if (updatedTransaction == null) throw new ArgumentNullException(nameof(updatedTransaction));
                if (!transactions.ContainsKey(updatedTransaction.Id))
                    throw new InvalidOperationException($"Transaction with ID {updatedTransaction.Id} not found.");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("UPDATE transactions SET Amount = @Amount, Description = @Description, CategoryId = @CategoryId," +
                        "Currency = @Currency, TransactionDate = @TransactionDate, ReceiptImage = @ReceiptImage WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Amount", updatedTransaction.Amount);
                    command.Parameters.AddWithValue("@Description", updatedTransaction.Description);
                    command.Parameters.AddWithValue("@CategoryId", updatedTransaction.Category.Id);
                    command.Parameters.AddWithValue("@Currency", updatedTransaction.Currency);
                    command.Parameters.AddWithValue("@TransactionDate", updatedTransaction.Date);
                    command.Parameters.AddWithValue("@ReceiptImage", updatedTransaction.ReceiptImage ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", updatedTransaction.Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception($"Transaction with Id {updatedTransaction.Id} not found.");
                    }
                }

                transactions[updatedTransaction.Id] = updatedTransaction;
                GetTransactionsFromDatabase();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error editing transaction: " + ex.Message);
            }
        }

        private void GetTransactionsFromDatabase()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("SELECT * FROM transactions WHERE UserId = @UserId", connection);
                    command.Parameters.AddWithValue("@UserId", SessionManager.currentUserId);

                    var categories = categoryManager.ReadAllUserCategories();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = categories.First(c => c.Id == reader.GetInt32("CategoryId"));

                            byte[] receiptImage = null;
                            if(!reader.IsDBNull(reader.GetOrdinal("ReceiptImage")))
                            {
                                receiptImage = (byte[])reader["ReceiptImage"];
                            }

                            var transaction = new Transaction(
                                reader.GetInt32("Id"),
                                reader.GetInt32("UserId"),
                                reader.GetFloat("Amount"),
                                reader.GetString("Description"),
                                category,
                                reader.GetString("Currency"),
                                reader.GetDateTime("TransactionDate"),
                                receiptImage
                                );

                            transactions[transaction.Id] = transaction;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting transactions from database: " + ex.Message);
            }
        }

        public void DeleteTransactionsByCategory(int categoryId)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    var transactionsToDelete = transactions.Values.Where(t => t.Category.Id == categoryId).ToList();
                    foreach (var transaction in transactionsToDelete)
                    {
                        BudgetForm budgetForm = new BudgetForm();
                        budgetForm.UpdateBudget(-transaction.Amount, transaction.Category);
                        transactions.Remove(transaction.Id);
                    }

                    var command = new MySqlCommand("DELETE FROM transactions WHERE CategoryId = @CategoryId", connection);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.ExecuteNonQuery();
                    GetTransactionsFromDatabase();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting transactions for category {categoryId}: {ex.Message}");
            }
        }
    }
}

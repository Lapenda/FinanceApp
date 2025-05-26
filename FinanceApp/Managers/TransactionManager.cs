using FinanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Managers
{
    internal class TransactionManager
    {
        private static readonly Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();

        public IReadOnlyCollection<Transaction> GetAllTransactions() => transactions.Values.ToList().AsReadOnly();

        public void Save(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transactions.ContainsKey(transaction.Id))
                throw new InvalidOperationException($"A transaction with ID {transaction.Id} already exists.");

            transactions[transaction.Id] = transaction;
        }

        public void Delete(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (!transactions.Remove(transaction.Id))
                throw new InvalidOperationException($"Transaction with ID {transaction.Id} not found.");
        }

        public void Replace(Transaction updatedTransaction)
        {
            if (updatedTransaction == null) throw new ArgumentNullException(nameof(updatedTransaction));
            if (!transactions.ContainsKey(updatedTransaction.Id))
                throw new InvalidOperationException($"Transaction with ID {updatedTransaction.Id} not found.");

            transactions[updatedTransaction.Id] = updatedTransaction;
        }
    }
}

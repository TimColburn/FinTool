using FinTool.Data.Data;
using FinTool.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FinTool.Data.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IFinToolDbContext db;

        public TransactionRepository(IFinToolDbContext db)
        {
            this.db = db;
        }

        public List<Transaction> GetAll()
        {
            var transactions = db.Transactions
                .Include(m => m.RegExString)
                .Include(m => m.RegExString.Category)
                .OrderByDescending(m => m.Date);

            return transactions.ToList();
        }

        public int Create (Transaction transaction)
        {
            var newTransaction = new Transaction()
            {
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                RegExString = transaction.RegExString,
            };
            db.Transactions.Add(newTransaction);
            return db.SaveChanges();
        }
    }
}

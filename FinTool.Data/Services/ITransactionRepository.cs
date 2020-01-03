using System.Collections.Generic;
using FinTool.Data.Models;

namespace FinTool.Data.Services
{
    public interface ITransactionRepository
    {
        int Create(Transaction transaction);
        List<Transaction> GetAll();
    }
}
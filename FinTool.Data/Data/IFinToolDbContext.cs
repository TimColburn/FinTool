using FinTool.Data.Models;
using System.Data.Entity;

namespace FinTool.Data.Data
{
    public interface IFinToolDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<RegExString> RegExStrings { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<MonthlyReport> MonthlyReports { get; set; }

        int SaveChanges();
    }
}
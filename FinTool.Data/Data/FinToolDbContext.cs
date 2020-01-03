using FinTool.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTool.Data.Data
{
    public class FinToolDbContext : DbContext, IFinToolDbContext
    {
        public FinToolDbContext() : base("FinTool20191226T1245")
        {
            Database.SetInitializer<FinToolDbContext>(new FinToolDbInitializer());
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RegExString> RegExStrings { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTool.Data.Models
{
    public class MonthlyReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public decimal Net { get; set; }
        public decimal Gain { get; set; }
        public decimal Loss { get; set; }
        public Dictionary<Category, decimal> MonthlyTotals { get; set; }
    }
}

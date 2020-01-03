using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTool.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public double DateSince1970InMilliseconds => (Date - new DateTime(1970, 1, 1)).TotalMilliseconds;
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public RegExString RegExString { get; set; }
    }
}

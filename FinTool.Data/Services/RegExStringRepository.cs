using FinTool.Data.Data;
using FinTool.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FinTool.Data.Services
{
    public class RegExStringRepository : IRegExStringRepository
    {
        private readonly IFinToolDbContext db;

        public RegExStringRepository(IFinToolDbContext db)
        {
            this.db = db;
        }

        public List<RegExString> GetAll()
        {
            var regExString = db.RegExStrings
                .Include(m => m.Category);
            return regExString.ToList();
        }


        public int Create (string searchString, string categoryName)
        {
            var category = db.Categories.SingleOrDefault(m => m.Name == categoryName);
            if (category == null)
            {
                category = new Category(categoryName);
                db.Categories.Add(category);
                db.SaveChanges();
            }

            var newRegExString = new RegExString()
            {
                SearchString = searchString,
                Category = category,
            };
            db.RegExStrings.Add(newRegExString);
            return db.SaveChanges();
        }
    }
}

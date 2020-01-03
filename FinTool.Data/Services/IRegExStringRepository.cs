using System.Collections.Generic;
using FinTool.Data.Models;

namespace FinTool.Data.Services
{
    public interface IRegExStringRepository
    {
        int Create(string searchString, string categoryName);
        List<RegExString> GetAll();
    }
}
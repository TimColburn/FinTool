using FinTool.Data.Models;
using FinTool.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinTool.Logic
{
    public class Helper
    {

        public static void LoadInputFiles(string filepath, ITransactionRepository transactionRepository, IRegExStringRepository regExStringRepository)
        {
            using (var reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var tokens = reader.ReadLine().Replace("\\", "").Replace("\"", "").Split(',');
                    var transaction = new Transaction()
                    {
                        Date = DateTime.Parse(tokens[0]),
                        Amount = Decimal.Parse(tokens[1]),
                        Description = tokens[4],
                        RegExString = GetRegExString(regExStringRepository, tokens[4]),
                    };
                    transactionRepository.Create(transaction);
                }
            }
        }


        private static RegExString GetRegExString(IRegExStringRepository regExStringRepository, string description)
        {
            foreach (var r in regExStringRepository.GetAll())
            {
                if (!String.IsNullOrEmpty(r.SearchString) && Regex.Match(description, r.SearchString).Success)
                    return r;
            }
            return regExStringRepository.GetAll().First(m => m.SearchString == "");
        }


        public static void GetCategoriesTableHeaders(ITransactionRepository transactionRepository, out List<object> columnHeaders, out List<string> rowHeaders)
        {
            columnHeaders = new List<object>();
            rowHeaders = new List<string>();
            var months = new List<DateTime>();

            foreach (var t in transactionRepository.GetAll())
            {
                months.Add(new DateTime(t.Date.Year, t.Date.Month, 1));
                rowHeaders.Add(t.RegExString.Category.Name);
            }
            rowHeaders = rowHeaders.Distinct().OrderBy(m => m).ToList();

            columnHeaders.Add(new { title = "Categories" });
            foreach (var c in months.Distinct().OrderBy(m => m))
                columnHeaders.Add(new { title = c.Month.ToString() + "/" + c.Year.ToString() });
        }


        public static List<List<decimal>> GetCategoriesTableData(ITransactionRepository transactionRepository, out List<object> columns, out List<List<decimal>> rows)
        {
            // get the raw data
            var totals = new SortedDictionary<DateTime, SortedDictionary<string, decimal>>();
            foreach (var t in transactionRepository.GetAll())
            {
                var date = new DateTime(t.Date.Year, t.Date.Month, 1);

                if (!totals.ContainsKey(date))
                    totals.Add(date, new SortedDictionary<string, decimal>());

                if (!totals[date].ContainsKey(t.RegExString.Category.Name))
                    totals[date].Add(t.RegExString.Category.Name, 0);

                totals[date][t.RegExString.Category.Name] += t.Amount;
            }

            // ensure all months contain the same list of categories
            foreach (var x in totals)
            {
                foreach (var y in totals)
                {
                    if (x.Key != y.Key)
                    {
                        foreach (var k in x.Value.Keys)
                        {
                            if (!y.Value.ContainsKey(k))
                                y.Value.Add(k, 0);
                        }
                    }
                }
            }

            // create the data rows
            var columnKeys = totals.Keys.ToList();
            List<string> categoryNames = totals[columnKeys[0]].Keys.ToList();
            rows = new List<List<decimal>>();
            var index = 0;
            foreach (var r in categoryNames)
            {
                var currentRow = new List<decimal>();
                currentRow.Add(index++);

                foreach (var c in columnKeys)
                    currentRow.Add(totals[c][r]);

                rows.Add(currentRow);
            }

            columns = new List<object>();
            foreach (var c in columnKeys)
                columns.Add(new { title = c.Month.ToString() + "/" + c.Year.ToString() });

            return rows;
        }


        public static void GetCateoriesChartData(List<string> rowHeaders, List<object> columns, List<List<decimal>> rows, out List<string> labels, out List<object> datasets)
        {
            labels = new List<string>();
            var a = new { title = "" };
            foreach (var c in columns)
                labels.Add(Cast(a, c).title);

            var index = 0;
            datasets = new List<object>();
            var rand = new Random();
            foreach (var r in rows)
            {
                datasets.Add(new
                {
                    data = r,
                    label = rowHeaders[index++],
                    borderColor = "#" + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString(),
                    fill = false,
                    hidden = true
                });
            }
            return;
        }

        private static T Cast<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic
            // to infer the type to cast x to
            return (T)x;
        }


    }
}
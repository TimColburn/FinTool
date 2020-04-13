using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTool.Logic
{
    public class CategoriesChartHelper
    {

        public static void GetData(List<string> rowHeaders, List<object> columns, List<List<decimal>> rows, out List<string> labels, out List<object> datasets)
        {
            labels = new List<string>();
            var a = new { title = "" };
            foreach (var c in columns)
                labels.Add(Cast(a, c).title);

            var index = 0;
            datasets = new List<object>();
            var rand = new Random();
            var hide = true;
            foreach (var r in rows)
            {
                hide = (rowHeaders[index] == "Auto" || rowHeaders[index] == "Misc Mortgage") ? false : true;

                datasets.Add(new
                {
                    data = r,
                    label = rowHeaders[index++],
                    borderColor = "#" + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString(),
                    fill = false,
                    hidden = hide
                });
            }
            return;
        }

        private static T Cast<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic to infer the type to cast x to
            return (T)x;
        }


    }
}
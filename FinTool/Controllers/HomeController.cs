using FinTool.Data.Services;
using FinTool.Logic;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinTool.Controllers
{
    public class HomeController : Controller
    {
        private const string filepath = @"C:\Git\FinTool\FinTool.Data\Test_Colter.txt";
        private readonly ITransactionRepository transactionRepository;
        private readonly IRegExStringRepository regExStringRepository;


        public HomeController(ITransactionRepository transactionRepository, IRegExStringRepository regExStringRepository)
        {
            this.transactionRepository = transactionRepository;
            this.regExStringRepository = regExStringRepository;
            Helper.LoadInputFiles(filepath, transactionRepository, regExStringRepository);
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetTransactions()
        {
            var transactions = transactionRepository.GetAll();
            return Json(transactions, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCategoriesTableHeaders()
        {
            Helper.GetCategoriesTableHeaders(transactionRepository, out List<object> columnHeaders, out List<string> rowHeaders);
            var headers = new { columnHeaders, rowHeaders };
            return Json(headers, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCategoriesTableData()
        {
            Helper.GetCategoriesTableData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCateoriesChartData()
        {
            Helper.GetCategoriesTableHeaders(transactionRepository, out List<object> columnHeaders, out List<string> rowHeaders);
            Helper.GetCategoriesTableData(transactionRepository, out List<object> columns, out List<List<decimal>> data);

            Helper.GetCateoriesChartData(rowHeaders, columns, data, out List<string> labels, out List<object> datasets);
            var x = new { labels, datasets };
            return Json(x, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetData()
        {
            Helper.GetCategoriesTableHeaders(transactionRepository, out List<object> categoryColumnHeaders, out List<string> categoryRowHeaders);
            Helper.GetCategoriesTableData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            Helper.GetCateoriesChartData(categoryRowHeaders, columns, data, out List<string> labels, out List<object> datasets);

            var x = new { categoryColumnHeaders, categoryRowHeaders, columns, data, labels, datasets };
            return Json(x, JsonRequestBehavior.AllowGet);
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
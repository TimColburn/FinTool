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

            var transactions = transactionRepository.GetAll();
            if (transactions.Count == 0)
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
            CategoriesTableHelper.GetHeaders(transactionRepository, out List<object> columnHeaders, out List<string> rowHeaders);
            var headers = new { columnHeaders, rowHeaders };
            return Json(headers, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCategoriesTableData()
        {
            CategoriesTableHelper.GetData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCateoriesChartData()
        {
            CategoriesTableHelper.GetHeaders(transactionRepository, out List<object> columnHeaders, out List<string> rowHeaders);
            CategoriesTableHelper.GetData(transactionRepository, out List<object> columns, out List<List<decimal>> data);

            CategoriesChartHelper.GetData(rowHeaders, columns, data, out List<string> labels, out List<object> datasets);
            var x = new { labels, datasets };
            return Json(x, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetData()
        {
            CategoriesTableHelper.GetHeaders(transactionRepository, out List<object> categoryColumnHeaders, out List<string> categoryRowHeaders);
            CategoriesTableHelper.GetData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            CategoriesChartHelper.GetData(categoryRowHeaders, columns, data, out List<string> labels, out List<object> datasets);

            var x = new { categoryColumnHeaders, categoryRowHeaders, columns, data, labels, datasets };
            return Json(x, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Tutorial()
        {
            ViewBag.Message = "The Tutorial page is coming soon!";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "The Help page is coming soon!";

            return View();
        }
    }
}
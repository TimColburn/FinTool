using FinTool.Data.Services;
using FinTool.Logic;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IRegExStringRepository regExStringRepository;


        public HomeController(ITransactionRepository transactionRepository, IRegExStringRepository regExStringRepository)
        {
            this.transactionRepository = transactionRepository;
            this.regExStringRepository = regExStringRepository;

            // load transaction data file into the database if needed
            if (transactionRepository.GetAll().Count == 0)
                Helper.LoadInputFile(transactionRepository, regExStringRepository);
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetTransactions()
        {
            var transactions = transactionRepository.GetAll();
            return Json(transactions, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetCategories()
        {
            CategoriesTableHelper.GetData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetCategoriesIncludingMetaData()
        {
            CategoriesTableHelper.GetHeaders(transactionRepository, out List<object> categoryColumnHeaders, out List<string> categoryRowHeaders);
            CategoriesTableHelper.GetData(transactionRepository, out List<object> columns, out List<List<decimal>> data);
            CategoriesChartHelper.GetData(categoryRowHeaders, columns, data, out List<string> labels, out List<object> datasets);

            var x = new { categoryColumnHeaders, categoryRowHeaders, columns, data, labels, datasets };
            return Json(x, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Tutorial()
        {
            ViewBag.Message = "The Tutorial page is coming soon!";
            return View();
        }


        [HttpGet]
        public ActionResult Help()
        {
            ViewBag.Message = "The Help page is coming soon!";
            return View();
        }

    }
}
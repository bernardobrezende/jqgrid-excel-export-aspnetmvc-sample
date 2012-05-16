using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Website.Models;
using Website.Utils;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private Products products;

        public HomeController()
        {
            this.products = new ProductsCollection();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts(string sidx, string sord, int page, int rows)
        {
            var jsonData = this.products
                .All()
                .ToJsonForjqGrid("Id", new[] { "Id", "Name" });
            //
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ExportResultToExcel(exportedFileName: "Products.xls", tempDataKey: "ProductsData")]
        public ActionResult ExportToExcel()
        {
            using (GridView grid = new GridView())
            {
                grid.DataSource = from p in this.products.All()
                                  select new
                                  {
                                      ProductName = p.Name,
                                      SomeProductId = p.Id
                                  };
                grid.DataBind();

                TempData["ProductsData"] = grid;
            }
            return View("Index");
        }
    }
}

using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
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
        public ActionResult ExportToExcel()
        {
            GridView grid = new GridView();
            grid.DataSource = from p in this.products.All()
                              select new
                              {
                                  ProductName = p.Name,
                                  SomeProductId = p.Id
                              };
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=MyGridData.xls");
            Response.ContentType = "application/ms-excel"; 

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    grid.RenderControl(htw);
                    Response.Write(sw.ToString());
                }
            }

            Response.End();

            return View("Index"); 
        }
    }
}

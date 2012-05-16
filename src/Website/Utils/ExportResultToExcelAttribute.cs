using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.Utils
{
    public class ExportResultToExcelAttribute : ActionFilterAttribute
    {
        private string exportedFileName;
        private string tempDataKey;

        /// <summary>
        /// Default constructor with default values for excel exportation.
        /// </summary>
        public ExportResultToExcelAttribute() : this("MyGridData.xls", "GridData") { }
        
        public ExportResultToExcelAttribute(string exportedFileName, string tempDataKey)
        {
            if (String.IsNullOrEmpty(exportedFileName))
                throw new ArgumentException("File name cannot be null or empty.");
            if (String.IsNullOrEmpty(tempDataKey))
                throw new ArgumentException("TempData key cannot be null or empty.");
            this.exportedFileName = exportedFileName;
            this.tempDataKey = tempDataKey;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (GridView grid = filterContext.Controller.TempData[this.tempDataKey] as GridView)
            {
                if (grid == null)
                    throw new InvalidOperationException("Cannot find data to export in TempData's dictionary.");

                filterContext.HttpContext.Response.ClearContent();
                filterContext.HttpContext.Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", this.exportedFileName));
                filterContext.HttpContext.Response.ContentType = "application/ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        grid.RenderControl(htw);
                        filterContext.HttpContext.Response.Write(sw.ToString());
                    }
                }
            }

            filterContext.HttpContext.Response.End();
            base.OnActionExecuted(filterContext);
        }
    }
}
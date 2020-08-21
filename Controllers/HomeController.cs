using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FastReportSimpleExample.Models;
using FastReport.Web;
using WebApplication1.Models;
using System.IO;

namespace FastReportSimpleExample.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        string reportToLoad { get; set; } = "Simplelist";



        [HttpGet]
        public IActionResult Index()
        {
            var myReport = new HomeModel()
            {
                WebReport = new WebReport(),
            };

            myReport.WebReport.Report.Load(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"{ reportToLoad}.frx"));
            var myItemtypeList = Services.GetItemtype();
            //var myConvertedTable = myItemtypeList.ConvertToDataSet("tm_itemtype");
            myReport.WebReport.Report.RegisterData(myItemtypeList.ConvertToDataSet("tm_itemtype"), "Database");
           // Report.GetDataSource("tableName").Enabled = true;
          // myReport.WebReport.Report.GetDataSource("tm_itemtype").Enabled = true;
            return View(myReport);
        }
    }
}

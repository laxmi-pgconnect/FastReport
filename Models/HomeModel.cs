using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastReport.Web;
namespace WebApplication1.Models
{
    public class HomeModel
    {
        public WebReport WebReport { get; set; }
        public string[] ReportsList { get; set; }
    }
}

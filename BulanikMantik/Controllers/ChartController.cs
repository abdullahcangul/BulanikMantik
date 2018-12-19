using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BulanikMantik.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult ChartGoster()
        {
            return View();
        }
        public ActionResult ChartOlustur(String tip= "Line")
        {
            Chart chart = new Chart(500, 500);
            chart.AddTitle("Isı ayarlayıcı 2000");
            chart.AddLegend("x ve y degerleri");

            chart.AddSeries(name: "x", chartType: tip,
                xValue: new[] { 15, 20, 50 },
                yValues: new[] { 20, 24, 45 });
           
            chart.AddSeries(name: "y", chartType: tip,
            xValue: new[] { 10, 20, 50 }, 
            yValues: new[] { 30, 26, 98 });
            return View(chart);
        }
    }
}
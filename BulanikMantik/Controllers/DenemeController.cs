using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace BulanikMantik.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Index()
        {
            Chart chart = new Chart();
            chart.BackColor = Color.Azure;
            Series series = new Series("asd");
            series.ChartType = SeriesChartType.Area;
            series.Color = Color.Black;
            series.BorderWidth = 5;

            return View();
        }
    }
}
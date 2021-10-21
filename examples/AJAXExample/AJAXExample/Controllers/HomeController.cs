using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJAXExample.Models;
using AJAXExample.DAL.Abstract;
using Microsoft.Extensions.Configuration;

namespace AJAXExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEarthquakeService _earthquakes;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IEarthquakeService e, IConfiguration configuration)
        {
            _logger = logger;
            _earthquakes = e;
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        // API Endpoints (only putting them here for convenience)
        [HttpGet]
        public IActionResult RandomNumbers(int? count = 100)
        {
            Debug.WriteLine("In Random Numbers: {0}",count);
            RandomNumbers obj = new RandomNumbers("Random Numbers API",(int)count,1000);
            return Json(obj);
        }

        [HttpGet]
        public IActionResult TimeRanges()
        {
            var selItems = Enum.GetValues<EarthquakeTimeRange>()
                               .Select(tr => new {
                                   Value = ((int)tr).ToString(),
                                   Text = Earthquake.TimeRanges[tr]})
                               .ToList();
            
            return Json(selItems);
        }

        [HttpPost]
        public IActionResult Earthquakes(int timeRange)
        {
            Debug.WriteLine("In Earthquakes: {0}",timeRange);
            EarthquakeTimeRange etr = (EarthquakeTimeRange)timeRange;
            if(!(etr >= EarthquakeTimeRange.PastHour && etr <= EarthquakeTimeRange.PastMonth))
            {
                etr = EarthquakeTimeRange.PastHour;
            }
            IEnumerable<Earthquake> quakes = _earthquakes.GetRecentEarthquakes(etr);
            return Json(quakes);
        }

        public IActionResult Privacy()
        {
            string key = _config["AJAXExample:GiphyKey"];
            Debug.WriteLine(key);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

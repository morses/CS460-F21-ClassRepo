using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;


namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Buyer> _buyerRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Buyer> buyerRepo)
        {
            _logger = logger;
            //_context = ctx;
            _buyerRepository = buyerRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Buyer> buyers = _buyerRepository.GetAll().ToList();
            return View(buyers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

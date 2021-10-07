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
        //private readonly AuctionHouseDbContext _context;
        private readonly IBuyerRepository _buyerRepository;

        //public HomeController(ILogger<HomeController> logger, AuctionHouseDbContext ctx)
        public HomeController(ILogger<HomeController> logger, IBuyerRepository buyerRepo)
        {
            _logger = logger;
            //_context = ctx;
            _buyerRepository = buyerRepo;
        }

        public IActionResult Index()
        {
            //AuctionHouseDbContext context = new AuctionHouseDbContext();
            /* IEnumerable<Buyer> buyers = _context.Buyers
                                                .Where(b => b.FirstName.Length > 3)
                                                .ToList(); */
            IEnumerable<Buyer> buyers = _buyerRepository.Buyers();  // GetAll()
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

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
    public class ItemsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemRepository _itemRepository;

        public ItemsController(ILogger<HomeController> logger, IItemRepository itemRepo)
        {
            _logger = logger;
            _itemRepository = itemRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> items = _itemRepository.Items();  // GetAll()
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            //...
            return View();
        }


    }
}

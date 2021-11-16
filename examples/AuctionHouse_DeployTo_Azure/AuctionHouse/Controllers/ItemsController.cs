using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;


namespace AuctionHouse.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Seller> _sellerRepository;

        public ItemsController(ILogger<HomeController> logger, IRepository<Item> itemRepo, IRepository<Seller> sellerRepo)
        {
            _logger = logger;
            _itemRepository = itemRepo;
            _sellerRepository = sellerRepo;
        }

        public IActionResult Index()
        {
            // for debugging:
            Item it = _itemRepository.FindById(3);

            // don't need bids but doing it here as an example
            IEnumerable<Item> items = _itemRepository.GetAll(i => i.Seller, i => i.Bids).ToList();
            return View(items);
        }

        // GET: Items/Create
        [HttpGet]
        public IActionResult Create()
        {
            // This is for a separate "create item" page.  We'll do it this way for now
            // since it is easier than putting it on the Index page
            // In order to create an Item we must know its Seller, so we must send
            // the create page a list of sellers with their ID's.  Pretend this is an admin
            // doing this so that it isn't silly that anyone can choose who the seller is :-)
            var selectList = new SelectList(
                _sellerRepository.GetAll().Select(s => new {Text = $"{s.FirstName} {s.LastName}",Value = s.Id}),
                "Value","Text");
            ViewData["SellerId"] = selectList;      // ViewData and ViewBag are the same thing
            return View();
        }

        // POST: Items/Create
        // We do NOT want to bind an ID coming from the user when doing a Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,SellerId")] Item item)
        {
            if( ModelState.IsValid )
            {
                // We have a model that passes any validation we've specified
                try
                {
                    _itemRepository.AddOrUpdate(item);
                }
                catch(DbUpdateConcurrencyException e)
                {
                    // Shouldn't happen during a create, but it since it could be thrown
                    // we must handle it
                    ViewBag.Message = "A concurrency error occurred while trying to create the item.  Please try again.";
                    return View(item);
                }
                catch(DbUpdateException e)
                {
                    ViewBag.Message = "An unknown database error occurred while trying to create the item.  Please try again.";
                    return View(item);
                }
                return RedirectToAction("Index");
            }
            else
            {
                // uncomment the next line if you want to see the error modal
                //ViewBag.Message = "An unknown database error occurred while trying to create the item.  Please try again.";
                // return validation errors and keep the user on this page and POST method
                var selectList = new SelectList(
                    _sellerRepository.GetAll().Select(s => new {Text = $"{s.FirstName} {s.LastName}",Value = s.Id}),
                    "Value","Text");
                ViewData["SellerId"] = selectList;
                return View(item);
            }
            
        }


    }
}

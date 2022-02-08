﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Fuji.Models;
using Fuji.DAL.Abstract;

namespace Fuji.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFujiUserRepository _fuRepo;
        private readonly IAppleRepository _appleRepo;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IFujiUserRepository fuRepo, IAppleRepository appleRepo)
        {
            _logger = logger;
            _userManager = userManager;
            _fuRepo = fuRepo;
            _appleRepo = appleRepo;
        }
        
        public async Task<IActionResult> Index()
        {
            // Information from Identity through the user manager
            string? id = _userManager.GetUserId(User);       // reportedly does not need to hit the db
            IdentityUser user = await _userManager.GetUserAsync(User);  // does go to the db

            FujiUser? fu = null;
            if(id != null)
            {
                fu = _fuRepo.GetFujiUserByIdentityId(id);
            }

            var appleList = _appleRepo.GetAll().ToList();
            MainPageVM vm = new MainPageVM { TheIdentityUser = user, TheFujiUser = fu, Apples = appleList };

            ViewBag.TotalConsumed = _appleRepo.GetTotalConsumed(_appleRepo.GetAll());

            return View(vm);
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

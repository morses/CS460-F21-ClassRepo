using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game.Models;
using Game.DAL.Abstract;
using Game.ViewModels;

namespace Game.Controllers
{
    public class CharacterController : Controller
    {

        private readonly ICharacterRepository _characterRepo;

        public CharacterController(ICharacterRepository characterRepo)
        {
            _characterRepo = characterRepo;
        }

        // Use the starter Index.cshtml page
        public IActionResult Index()
        {
            // just so it will complile/run, replace with your implementation
            IEnumerable<Character> characters = new List<Character>();


            return View(characters);
        }

        // Use the starter Details.cshtml page
        public IActionResult Details(int? id)
        {
            int cid = id.Value;
            if(id == null || !_characterRepo.Exists(cid))
            {
                return View(null);
            }
            // Your implementation here





            return View();
        }

        [HttpPost]
        public JsonResult LevelUp(int? id)
        {
            int cid = id.Value;
            if(id == null || !_characterRepo.Exists(cid))
            {
                return Json(new { Error = "id is not valid"});
            }
            // your implementation here



            return Json(new { Level = 1 }); // just so it will run until implemented
        }
    }
}

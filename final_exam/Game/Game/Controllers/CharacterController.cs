using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game.Models;
using Game.DAL.Abstract;

namespace Game.Controllers
{
    public class CharacterController : Controller
    {
        // A new version of this file will be available just prior to the exam.  Replace this file with that one.

        private readonly ICharacterRepository _characterRepo;

        public CharacterController(ICharacterRepository characterRepo)
        {
            _characterRepo = characterRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

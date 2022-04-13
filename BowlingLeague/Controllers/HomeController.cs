using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {

        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers.ToList();


            return View(blah);
        }

        // ADD BOWLER
        [HttpGet]
        public IActionResult BowlerForm(int bowlerid)
        {
            ViewBag.Bowlers = _repo.Bowlers.ToList();
            return RedirectToAction("EditBowler", bowlerid);
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Bowlers = _repo.Bowlers.ToList();
                return View(b);
            }
        }

        // EDIT BOWLER
        [HttpGet]
        public IActionResult EditBowler(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler b)
        {
            _repo.SaveBowler(b);

            return RedirectToAction("Index");
        }

        // DELETE BOWLER
        [HttpGet]
        public IActionResult DeleteBowler(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult DeleteBowler(Bowler b)
        {
            _repo.DeleteBowler(b);

            return RedirectToAction("ViewAppts");
        }
    }
}

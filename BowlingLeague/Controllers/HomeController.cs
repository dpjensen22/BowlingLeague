using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using Microsoft.EntityFrameworkCore;


namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }

        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        //public IActionResult Index()
        //{
        //    var bowlers = _repo.Bowlers
        //    .ToList();
        //    return View(bowlers);
        //}

        public IActionResult Index(string teamName)
        {

            //collects list of bowlers, including their teams
            var x = _repo.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .OrderBy(b => b.Team.TeamName)
                .ToList();
            


            return View(x);
        }



        [HttpGet]
        public IActionResult CreateBowler()
        {
            //brings in teams list
            ViewBag.Teams = _repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateBowler(Bowler b)
        {

            if (ModelState.IsValid)
            {
                    b.BowlerID = (_repo.Bowlers.Max(b => b.BowlerID)) + 1;
                    _repo.CreateBowler(b);
                    return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View(b);
            }

        }


        //adds ability to Edit and Delete bowler information

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {

            ViewBag.Teams = _repo.Teams.ToList();
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("CreateBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler update)
        {
            _repo.SaveBowler(update);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Bowler delete)
        {
            _repo.DeleteBowler(delete);
            
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BowlingLeague.Models;

namespace BowlingLeague.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlingRepository repo { get; set; }

        public TeamsViewComponent(IBowlingRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];
            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);
            return View(teams);
        }
    }
}
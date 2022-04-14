using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BowlingLeague.Models;

namespace BowlingLeague.Components
{
    public class LabelViewComponent : ViewComponent
    {
        private IBowlingRepository repo { get; set; }

        public LabelViewComponent(IBowlingRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];
            var label = RouteData?.Values["teamName"];
            return View(label);
        }
    }
}
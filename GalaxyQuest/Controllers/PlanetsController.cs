using GalaxyQuest.Models;
using GalaxyQuest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyQuest.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly MilkyWayGalaxy _milkyWayGalaxy;

        public PlanetsController(MilkyWayGalaxy milkyWayGalaxy)
        {
            _milkyWayGalaxy = milkyWayGalaxy;
        }

        public async Task<IActionResult> Index()
        {
            var milkyWayPlanets = MilkyWayGalaxy.Planets;
            return View(milkyWayPlanets);
            //var planets = new List<Planet>();
            //planets = await _milkyWayGalaxy.GetPlanets();
            //return View(planets);
        }
    }
}

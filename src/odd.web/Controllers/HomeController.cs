using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using odd.web.Models;
using odd.web.Services;

namespace odd.web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IOddServices oddService, ITeamServices teamService) : base (oddService, teamService)
        {

        }
        public IActionResult index()
        {
            return View(_oddService.ClientQueryOdds());
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

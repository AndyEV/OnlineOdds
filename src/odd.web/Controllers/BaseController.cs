using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using odd.web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace odd.web.Controllers
{
    public class BaseController : Controller
    {
        public IOddServices _oddService;
        public ITeamServices _teamService;
        public BaseController(IOddServices oddService, ITeamServices teamService)
        {
            _oddService = oddService;
            _teamService = teamService;
        }
    }
}

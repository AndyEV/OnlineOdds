﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using odd.services;
using odd.web.Models;
using odd.web.Services;
using odd.web.Services.Validations;

namespace odd.web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IOddServices _oddService;
        public HomeController(IOddServices oddService)
        {
            _oddService = oddService;
        }
        public IActionResult index()
        {
            return View(_oddService.ClientQueryOdds());
        }

        public IActionResult GetLatestOddData()
        {
            return Ok(_oddService.ClientQueryOdds());
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using odd.web.DTOs;
using odd.web.Services;
using odd.web.Services.Validations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace odd.web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly OddDtoValidator _validator;

        public AdminController(IOddServices oddService, ITeamServices teamService, OddDtoValidator validator) : base(oddService, teamService)
        {
            _validator = validator;
        }

        // GET: /<controller>/
        public IActionResult index()
        {

            ViewData["Odds"] = _oddService.ClientQueryOdds();
            return View();
        }

        public IActionResult odd_entry()
        {
            // This would probably be at the service level
            var data = new List<SelectListItem> { new SelectListItem { Value = Guid.Empty.ToString(), Text = "Select..." } };
            data.AddRange(_teamService.QueryTeams().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"{x.HomeTeam} VS {x.AwayTeam}" }));
            ViewBag.Teams = data;
            return View();
        }

        [HttpPost]
        public IActionResult odd_entry(CreateOdd dto)
        {
            var data = new List<SelectListItem> { new SelectListItem { Text = "Select..." } };
            data.AddRange(_teamService.QueryTeams().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"{x.HomeTeam} VS {x.AwayTeam}" }));
            ViewBag.Teams = data;

            // This would probably be at the service level
            if (dto.TeamId == Guid.Empty && string.IsNullOrEmpty(dto.HomeTeam))
            {
                ViewBag.error = "Make sure team pair is selected";
                return View(dto);
            }

            var results = _validator.Validate(dto);

            if(!results.IsValid)
            {
                results.AddToModelState(ModelState, null);

                return View(dto);
            }
            
            _oddService.CreateOddAndTeam(dto);

            return RedirectToAction(nameof(index));
        }
    }
}

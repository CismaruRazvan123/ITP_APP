using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP_App.ApplicationLogic.Services;
using ITP_App.Models.Admins;
using ITP_App.Models.Clients;
using Microsoft.AspNetCore.Mvc;

namespace ITP_App.Controllers
{
    public class CommonController : Controller
    {
        private readonly AdminsService adminsService;
        private readonly ClientsService clientsService;

        public CommonController(AdminsService adminsService, ClientsService clientsService)
        {
            this.adminsService = adminsService;
            this.clientsService = clientsService;
        }
        
        [HttpGet]
        public IActionResult Cars()
        {
            try
            {
                var cars = adminsService.GetCars();
                return View(new CarsViewModel { Cars = cars });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult Reviews()
        {
            try
            {
                var reviews = clientsService.GetReviews();
                return View(new ReviewViewModel { Reviews = reviews });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult Rules()
        {
            try
            {
                var rules = adminsService.GetRules();
                return View(new RulesViewModel { Rules = rules });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }
    }
}
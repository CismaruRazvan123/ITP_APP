using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITP_App;
using ITP_App.Models;
using Microsoft.AspNetCore.Authorization;
using ITP_App.ApplicationLogic.Services;
using ITP_App.Models.Admins;

namespace ITP_App.Controllers
{
   
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly AdminsService adminsService;

        public AdminsController(AdminsService adminsService)
        {
            this.adminsService = adminsService;
        }

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }
        
        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar([FromForm]AddCarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminsService.AddCar(model.CarType, model.CivSeries,
                                    model.BodySeries, model.CarMileage, 
                                    model.YearOfManufacture, model.ItpValability, model.OwnerFirstName,
                                    model.OwnerLastName, model.OwnerCNP);
            return Redirect(Url.Action("Index", "Admins"));
        }

        [HttpGet]
        public IActionResult AddRule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRule([FromForm]AddRuleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminsService.AddRule(model.Name, model.Text);
            return Redirect(Url.Action("Index", "Admins"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITP_App;
using ITP_App.Models;
using ITP_App.ApplicationLogic.Services;
using Microsoft.AspNetCore.Authorization;
using ITP_App.Models.Clients;
using ITP_App.ApplicationLogic.DataModel;

namespace ITP_App.Controllers
{
    
    [Authorize(Roles = "Client")]
    public class ClientsController : Controller
    {
        private readonly ClientsService clientsService;
        private readonly AdminsService adminsService;

        public ClientsController(ClientsService clientsService, AdminsService adminsService)
        {
            this.clientsService = clientsService;
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
        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReview([FromForm]AddReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            clientsService.AddReview(model.Rating, model.Title, model.Text);
            return Redirect(Url.Action("Index", "Clients"));
        }

        [HttpGet]
        public IActionResult SearchCar(string searchBy, string search)
        {
            switch (searchBy)
            {
                case "CivSeries":
                    return View(new SearchCarViewModel { Cars = adminsService.GetCarByCivSeries(search) });
                case "BodySeries":
                    return View(new SearchCarViewModel { Cars = adminsService.GetCarByBodySeries(search) });
                default:
                    var cars = adminsService.GetCars();
                    return View(new SearchCarViewModel { Cars = cars });
            }
        }
    }
}

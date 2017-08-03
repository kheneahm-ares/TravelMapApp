using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {

        private IMailService mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        //dependency injection!!!!
        //this mail service being passed is actually the DebugMailService object
        public AppController(IMailService mailService, IConfigurationRoot config, 
            IWorldRepository repository, ILogger<AppController> logger)
        {
            this.mailService = mailService;

            _config = config;
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {

            //var trips = _repository.GetAllTrips(); //going to a database and query for trips; in our case we are using SQL server

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            if (model.Email.Contains("aol.com"))
            {
                //a model error with no name is a model only 
                ModelState.AddModelError("Email", "We don't support AOL addresses");
            }

            if (ModelState.IsValid)
            {
                mailService.sendMail(_config["MailSettings:ToAddress"], model.Email, "From THe World", model.Message);

                ModelState.Clear();  //so that when the form is sent the form inputs are cleared!

                ViewBag.UserMessage = "Message Sent!";
            }
            return View();
        }


        public IActionResult About()
        {
            return View();
        }
    }
}

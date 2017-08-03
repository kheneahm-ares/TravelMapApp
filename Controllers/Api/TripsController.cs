using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{

    [Route("/api/trips")]
    [Authorize]
    public class TripsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripsController> _logger;


        //note that the repository is a way for us to access the database and avoid redundant data access code
        public TripsController(IWorldRepository repository, ILogger<TripsController> logger) 
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("")]
        public IActionResult Get()
        {

            // if (true) return BadRequest("Bad Thigns Happened");
            try {
                var results = _repository.GetTripByUsername(this.User.Identity.Name);

                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results)); //create an ok result of TripViewModels that are Ienumerable 


                }
            catch(Exception ex)
            {

                //logging 
                _logger.LogError($"Failed to get All trips: {ex}");
                return BadRequest("Error Occurred");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip) //need from body so that it knows where to grab the trip data 
        {

            if (ModelState.IsValid)
            {
                //save to database
                var newTrip = Mapper.Map<Trip>(theTrip);

                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }

            }

            return BadRequest("Failefd to Save the Trip");

        }
    }
}

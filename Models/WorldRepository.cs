using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddStop(string tripName, Stop newStop, string userName)
        {
            var trip = GetUserTripByName(tripName, userName);

            if(trip != null)
            {
              
                trip.Stops.Add(newStop);
                _context.Stops.Add(newStop);
            }
        }

        public void AddTrip(Trip newTrip) //note that our context object gives us the ability to add to our database
        {
            _context.Add(newTrip);
            
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting All Trips From the Database");
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName)
        {

            //we are able to query this property because it is a DbContext instance of the Trip Class
            //using lambda expression to create a standard linq query
            return _context.Trips
                .Include(t => t.Stops)
                .Where(t => t.Name == tripName)
                .FirstOrDefault();
        }

        public IEnumerable<Trip> GetTripByUsername(string name)
        {
            return _context
                 .Trips
                 .Include(t => t.Stops)
                 .Where(t => t.UserName == name)
                 .ToList();
        }

        public Trip GetUserTripByName(string tripName, string userName)
        {
            return _context
                 .Trips
                 .Include(t => t.Stops)
                 .Where(t => t.Name == tripName && t.UserName == userName)
                 .FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }

}

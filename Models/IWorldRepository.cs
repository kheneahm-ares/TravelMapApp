using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripByUsername(string username);
        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string username);

        void AddStop(string tripName, Stop newStop, string username);
        void AddTrip(Trip newTrip);
        
        
        //save all changes that have been added to our repository all at once
        Task<bool> SaveChangesAsync();
    }
}
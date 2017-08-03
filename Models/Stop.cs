using System;

namespace TheWorld.Models
{
    public class Stop
    {

        public int Id { get; set; } //primary key
        public string Name { get; set; } //name of city
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Order { get; set; }
        public DateTime Arrival { get; set; }
    }
}
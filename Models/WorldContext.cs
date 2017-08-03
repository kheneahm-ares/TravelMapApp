using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    //inherit from IdentityDbContext since we our adding Identity to our database
    //, takes in a generic that is going to store our user info (WorldUser)
    //this class represents the different types of data in our database
    public class WorldContext : IdentityDbContext<WorldUser> //what this class does is it enables us to make linq queries for our data
    {
        private IConfigurationRoot _config;

        //dependency injection via constructor injection 
        public WorldContext(IConfigurationRoot config, DbContextOptions options) //have to inject options in order to use OnConfiguring
            :base(options)
        {
            _config = config;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]); //pass connection string
        }
    }


}

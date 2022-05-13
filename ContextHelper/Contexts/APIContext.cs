using ContextHelper.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContextHelper.Contexts
{
    public class ApiContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
            LoadAirlines();
        }

        public void LoadAirlines()
        {
            Airline airline = new Airline() 
            { 
                AirlineName = "AirIndia",
                AirlineLogo = "/AirIndiaLogo",
                ContactNumber = "56789",
                ContactAddress = "street1",
                IsBlocked = false
            };
            Airlines.Add(airline);
            airline = new Airline()
            {
                AirlineName = "IndiGo",
                AirlineLogo = "/IndoGoLogo",
                ContactNumber = "45678",
                ContactAddress = "street2",
                IsBlocked = false
            };
            Airlines.Add(airline);
        }

        public List<Airline> GetAirlines()
        {
            return Airlines.Local.ToList<Airline>();
        }
    }
}

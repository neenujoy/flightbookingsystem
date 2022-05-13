using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Models
{
    public class Inventory
    {
        public int flightId { get; set; }
        public string FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotalBCSeats { get; set; }
        public int TotalNBCSeats { get; set; }
        public int NumberOfRows { get; set; }
        public string MealType { get; set; }
        public float BCTicketCost { get; set; }
        public float NBCTicketCost { get; set; }
    }
}

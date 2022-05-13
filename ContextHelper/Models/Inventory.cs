using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextHelper.Models
{
    public class Inventory
    {
        public string FlightNumber { get; set; }
        public int Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotalBClassSeats { get; set; }
        public int TotalNBCSeats { get; set; }
        public decimal BCSeatCoast { get; set; }
        public decimal NBCSeatCost { get; set; }
    }
}

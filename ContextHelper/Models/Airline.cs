using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextHelper.Models
{
    public class Airline
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public bool IsBlocked { get; set; }
    }
}

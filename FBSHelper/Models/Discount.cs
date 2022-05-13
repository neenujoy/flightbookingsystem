using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Models
{
    public class Discount
    {
        public string Code { get; set; }
        public int Amount { get; set; }
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
    }
}

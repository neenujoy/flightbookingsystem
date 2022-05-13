using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Models
{
    public class Booking
    {
        public int FlightId { get; set; }
        public int BookingId { get; set; }
        public string FlightNumber { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int NumberOfSeats { get; set; }
        public string MealType { get; set; }
        public DateTime BookedDate { get; set; }
        public string TripMode { get; set; }
        public int TotalCost { get; set; }
        public string PNRNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public bool IsAbleToCancel { get; set; }
        public List<Passenger> PassengerDetails { get; set; }
    }

    public class Passenger
    {
        public int PassengerId { get; set; }
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SeatNo { get; set; }
    }
}

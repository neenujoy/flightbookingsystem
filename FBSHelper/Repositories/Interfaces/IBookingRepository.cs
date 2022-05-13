using FBSHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        string BookFlight(Booking bookingData);
        Booking GetBookingDetailsByPNRNumber(string pnrNumber);
        List<Booking> GetBookingDetailsByEmail(string email);
        bool CancelBookingByPNRNumber(string pnrNumber);
        Discount GetDiscountByCode(string code);
        List<int> GetSeats(int id);
    }
}

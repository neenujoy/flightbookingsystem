using FBSHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories.Interfaces
{
    public interface IAirlineRepository
    {
        bool RegisterAirlines(Airline airlineData);
        List<Airline> GetAirlines();
        Airline GetAirlineByName(string name);
        bool UpdateAirlines(int id, Airline airlineData);
        Discount GetDiscountByCode(string code);
        bool AddDiscount(Discount discountData);
        List<Discount> GetDiscounts();
    }
}

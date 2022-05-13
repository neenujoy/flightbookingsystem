using FBSHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        bool AddInventory(Inventory inventoryData);
        List<Inventory> GetAllInventories();
        Inventory GetInventoryByFlightNumberAndStartDate(string flightNumber, DateTime startTime);
        List<Inventory> GetAllFlightDetails(string fromPlace, string toPlace, DateTime? startDate, DateTime? endDate, string tripMode);
        Inventory GetFlightById(int id);

    }
}

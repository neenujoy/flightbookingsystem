using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository inventoryRepository;
        public InventoryController(IInventoryRepository inventoryRepo)
        {
            this.inventoryRepository = inventoryRepo;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllInventories()
        {
            List<Inventory> inventoryLists = inventoryRepository.GetAllInventories();
            return Ok(inventoryLists);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddInventory([FromBody] Inventory inventory)
        {
            if (inventory == null)
                return BadRequest();

            Inventory inventoryData = inventoryRepository.GetInventoryByFlightNumberAndStartDate(inventory.FlightNumber, inventory.StartDate);
            if (inventoryData != null &&  !string.IsNullOrEmpty(inventoryData.FlightNumber))
            {
                return Ok("DataExist!");
            }

            bool isInserted = inventoryRepository.AddInventory(inventory);
            if (isInserted)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("GetAllFlightDetails/")]
        public IActionResult GetAllFlightDetails(string fromPlace, string toPlace, DateTime? startDate, DateTime? endDate, string tripMode)
        {
            List<Inventory> inventoryLists = inventoryRepository.GetAllFlightDetails(fromPlace, toPlace, startDate, endDate, tripMode);
            return Ok(inventoryLists);
        }

        [HttpGet("GetFlightById/")]
        public IActionResult GetAllFlightDetails(int id)
        {
            Inventory inventory = inventoryRepository.GetFlightById(id);
            return Ok(inventory);
        }
    }
}

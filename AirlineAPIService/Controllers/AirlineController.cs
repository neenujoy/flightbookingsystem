using FBSHelper.Authentication.Interfaces;
using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AirlineAPIService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineRepository airlineRepository;

        public AirlineController(IAirlineRepository airlineRepo)
        {
            this.airlineRepository = airlineRepo;
        }

        [HttpGet]
        public IActionResult GetAllAirlines()
        {
            List<Airline> airlines = airlineRepository.GetAirlines();
            return Ok(airlines);
        }

        [HttpGet("isairlineexist/")]
        public IActionResult IsAirlineExist(string airlineName)
        {
            Airline airlineData = airlineRepository.GetAirlineByName(airlineName);
            if (airlineData != null && airlineData.AirlineId != 0)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        public IActionResult Register([FromBody]Airline airline)
        {
            if (airline == null)
                return BadRequest();

            Airline airlineData = airlineRepository.GetAirlineByName(airline.AirlineName);
            if(airlineData != null && airlineData.AirlineId != 0)
            {
                return Ok("DataExist!");
            }

            bool isInserted = airlineRepository.RegisterAirlines(airline);
            if (isInserted)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPut("UpdateAirline/{id}")]
        public IActionResult UpdateAirlineByID(int id, [FromBody] Airline airline)
        {
            if (airline == null)
                return BadRequest();

            bool isUpdated = airlineRepository.UpdateAirlines(id, airline);
            if (isUpdated)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost("Adddiscount/")]
        public IActionResult AddDiscount([FromBody] Discount discount)
        {
            if (discount == null)
                return BadRequest();

            Discount discountData = airlineRepository.GetDiscountByCode(discount.Code);
            if (discountData != null && discountData.Code == discount.Code)
            {
                return Ok("Code Exist");
            }

            bool isInserted = airlineRepository.AddDiscount(discount);
            if (isInserted)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }


        [HttpGet("getdiscounts/")]
        public IActionResult GetDiscounts()
        {
            List<Discount> discounts = airlineRepository.GetDiscounts();
            return Ok(discounts);
        }
        [HttpGet("isdiscountcodeexist/")]
        public IActionResult IsDiscountCodeExist(string code)
        {
            Discount discountData = airlineRepository.GetDiscountByCode(code);
            if (discountData != null && discountData.AirlineId != 0)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}

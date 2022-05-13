using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using FBSHelper.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository bookingRepository;
        public BookingController(IBookingRepository bookingRepo)
        {
            this.bookingRepository = bookingRepo;
        }


        [HttpPost("flight/book")]
        public IActionResult BookFlight([FromBody] Booking bookingDetails)
        {
            if (bookingDetails == null)
                return BadRequest();

            string pnrNumber = bookingRepository.BookFlight(bookingDetails);
            if (!string.IsNullOrEmpty(pnrNumber))
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("bookingDetails/")]
        public IActionResult GetBookingDetails(string pnrNumber)
        {
            Booking bookingDetails = bookingRepository.GetBookingDetailsByPNRNumber(pnrNumber);
            return Ok(bookingDetails);
        }

        [HttpGet("bookinghistory/")]
        public IActionResult GetBookingHistory(string email)
        {
            List<Booking> bookingDetails = bookingRepository.GetBookingDetailsByEmail(email);
            return Ok(bookingDetails);
        }

        [HttpDelete("cancelbooking/")]
        public IActionResult CancelBooking(string pnrNumber)
        {
            CancelResponse response = new CancelResponse();
            Booking bookingData = bookingRepository.GetBookingDetailsByPNRNumber(pnrNumber);
            if (bookingData != null && bookingData.PNRNumber == pnrNumber)
            {
                DateTime now = DateTime.Now;
                if (bookingData.BookedDate > now.AddHours(-24) && bookingData.BookedDate <= now)
                {
                    response.IsCanceled = false;
                    response.Message = "You cannot cancel ticket";
                    return Ok(response);
                }
            }
            bool isCanceled = bookingRepository.CancelBookingByPNRNumber(pnrNumber);
            if (isCanceled)
            {
                response.IsCanceled = true;
                response.Message = "Successfully canceled";
            }
            else
            {
                response.IsCanceled = false;
                response.Message = "Cancellation failed";
            }

            return Ok(response);
        }

        [HttpGet("GetDiscountByCode/")]
        public IActionResult GetDiscountByCode(string code)
        {
            Discount discount = bookingRepository.GetDiscountByCode(code);
            return Ok(discount);
        }

        [HttpGet("GetSeats/")]
        public IActionResult GetSeats(int id)
        {
            List<int> seatsList = bookingRepository.GetSeats(id);
            return Ok(seatsList);
        }
    }
}

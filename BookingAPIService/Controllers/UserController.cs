using FBSHelper.Authentication.Interfaces;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthService jwtAuth;
        public UserController(IUserRepository userRepo, IAuthService jwtAuth)
        {
            this.userRepository = userRepo;
            this.jwtAuth = jwtAuth;
        }

        [HttpPost("AddUser/")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            User userData = userRepository.GetUserByUsername(user.Email);
            if (userData != null && userData.Email == user.Email)
            {
                return Ok("Data exist");
            }
            user.UserId = Guid.NewGuid();
            user.UserRole = Role.User;
            bool isInserted = userRepository.AddUser(user);
            if (isInserted)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("isemailexist/")]
        public IActionResult IsEmailExist(string email)
        {
            User userData = userRepository.GetUserByUsername(email);
            if (userData != null && userData.Email == email)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost("Login/")]
        public IActionResult Login(Login loginData)
        {
            LoginResponse response = new LoginResponse();
            response = jwtAuth.Authentication(loginData);
            if (response == null || response.Token == null)
            {
                return Ok(new LoginResponse());
            }
            return Ok(response);
        }

    }
}

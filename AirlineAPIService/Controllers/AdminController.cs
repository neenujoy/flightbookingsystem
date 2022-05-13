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

namespace AirlineAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthService jwtAuth;
        public AdminController(IAuthService jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }
        [HttpPost("login/")]
        public IActionResult Login(Login userCredential)
        {
            LoginResponse response = new LoginResponse();
            response = jwtAuth.Authentication(userCredential);
            if (response == null || response.Token == null) {
                return Ok(new LoginResponse());
            }
            return Ok(response);
        }
        //private readonly IUserRepository userRepository;
        //public AdminController(IUserRepository userRepo)
        //{
        //    this.userRepository = userRepo;
        //}
        //[HttpPost("Login/")]
        //public IActionResult Login(Login loginData)
        //{
        //    User userDetails = userRepository.GetUserByUsernameAndPassword(loginData);
        //    if (userDetails != null && userDetails.UserRole == Role.Admin)
        //        return Ok(true);
        //    else
        //        return Ok(false);
        //}
    }
}

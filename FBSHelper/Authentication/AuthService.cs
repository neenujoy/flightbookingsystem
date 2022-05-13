using FBSHelper.Authentication.Interfaces;
using FBSHelper.Models;
using FBSHelper.Repositories.Interfaces;
using FBSHelper.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly string key;
        private readonly IUserRepository userRepository;
        public AuthService(string key, IUserRepository userRepo)
        {
            this.key = key;
            this.userRepository = userRepo;
        }
        public LoginResponse Authentication(Login loginData)
        {
            LoginResponse userResponse = new LoginResponse();
            User userDetails = userRepository.GetUserByUsernameAndPassword(loginData);
            if (userDetails == null || userDetails.Email == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(GetUserClaims(userDetails)),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenValue = tokenHandler.WriteToken(token);
            userResponse.UserId = userDetails.UserId;
            userResponse.Email = userDetails.Email;
            userResponse.Role = userDetails.UserRole;
            userResponse.Token = tokenValue;
            userResponse.Status = "Success";
            return userResponse;
        }

        private IEnumerable<Claim> GetUserClaims(User user)
        {

            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.Email);
            claims.Add(_claim);

            _claim = new Claim("Role", user.UserRole.ToString());
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }
    }
}

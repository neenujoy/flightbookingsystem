using FBSHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Responses
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
    }
}

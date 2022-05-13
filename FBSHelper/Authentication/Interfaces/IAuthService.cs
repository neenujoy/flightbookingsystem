using FBSHelper.Models;
using FBSHelper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Authentication.Interfaces
{
    public interface IAuthService
    {
        LoginResponse Authentication(Login loginData);
    }
}

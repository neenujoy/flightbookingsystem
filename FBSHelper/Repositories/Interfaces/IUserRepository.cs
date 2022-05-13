using FBSHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBSHelper.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsernameAndPassword(Login loginDetails);
        User GetUserByUsername(string username);
        bool AddUser(User userData);
    }
}

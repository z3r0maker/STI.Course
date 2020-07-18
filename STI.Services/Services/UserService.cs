using STI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Services.Services
{
    public class UserService : IUserService
    {
        public string GetDefaultUser() 
        {
            return "DefaultUser";
        }
    }
}

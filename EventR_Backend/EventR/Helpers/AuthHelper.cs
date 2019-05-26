using EventRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Helpers
{
    public class AuthHelper
    {
        public static User Authenticate(string email, string password, Context context)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = context.users.Where(x=> x.Email == email && x.Password == password).SingleOrDefault();

            if (user == null)
                return null;            

            return user;
        }
    }
}

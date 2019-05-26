using EventRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Helpers
{
    public class AuthHelper
    {
        public static User Authenticate(string nickname, string password, Context context)
        {
            if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password))
                return null;

            var user = context.users.Where(x=> x.Nickname == nickname && x.Password == password).SingleOrDefault();

            if (user == null)
                return null;            

            return user;
        }
    }
}

using EventRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EventR.Helpers
{
    public class AuthHelper
    {
        public static byte[] CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            return buff;
        }

        public static byte[] CreateHash(string pass, byte[] salt)
        {
            return new HMACSHA512(salt).ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
        }

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

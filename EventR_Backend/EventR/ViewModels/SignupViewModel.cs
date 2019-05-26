using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.ViewModels
{
    public class SignupViewModel
    {
        public string NickName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AccessLevel { get; set; }
    }
}

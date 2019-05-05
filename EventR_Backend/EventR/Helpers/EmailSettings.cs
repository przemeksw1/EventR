using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Helpers
{
    public class EmailSettings
    {
            /// <summary>
            /// Host usługi 
            /// </summary>
            public string Host { get; set; }
            /// <summary>
            /// Port usługi
            /// </summary>
            public int Port { get; set; }
            /// <summary>
            /// Konto email systemu
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Hasło do konta systemu
            /// </summary>
            public string Password { get; set; }
        
    }
}

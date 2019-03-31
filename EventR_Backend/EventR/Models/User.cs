using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class User
    {
        [Key] public int UserId { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public char State { get; set; }
        public int AccessLevel { get; set; }
        public string Avatar { get; set; } //link do grafiki

        //Lista obserowanych wydarzen - tabela WydarzeniaObserwowane
        public virtual ICollection<Event> ObservatedEvents { get; set; }

        //Lista wydarzen polubionych przez uzytkownika - tabela Polubienia
        public virtual ICollection<Event> LikedEvents { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Uzytkownicy
    {
        [Key] public int Id_Uytkownika { get; set; }
        public string Nick { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int NumerTel { get; set; }
        public char Status { get; set; }
        public int Poziom_Konta { get; set; }
        public string Avatar { get; set; } //link do grafiki

        //Lista obserowanych wydarzen - tabela WydarzeniaObserwowane
        public virtual ICollection<Wydarzenia> Wydarzenia_Obserwowane { get; set; }

        //Lista wydarzen polubionych przez uzytkownika - tabela Polubienia
        public virtual ICollection<Wydarzenia> Wydarzenia_Lubiane { get; set; }
    }
}

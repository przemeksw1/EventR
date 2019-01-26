using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Preferencje
    {
        [Key] public int Id_Preferencji { get; set; }
        [ForeignKey("Uzytkownicy")] public int Id_Uzytkownika { get; set; }
        public string Typ { get; set; }
        public string Preferencja { get; set; }
    }
}

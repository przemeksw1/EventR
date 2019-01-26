using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Grafiki
    {
        [Key] public int Id_Grafiki { get; set; }
        [ForeignKey("Uzytkownicy")] public int Id_Autora { get; set; }
        [ForeignKey("Wydarzenia")] public int Id_Wydarzenia { get; set; }
        public string Grafika { get; set; } //link do grafiki
    }
}

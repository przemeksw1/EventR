using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Wydarzenia
    {
        [Key] public int Id_Wydarzenia { get; set; }
        [ForeignKey("Uzytkownicy")] public int Id_Autora { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime Data { get; set; }
        public string Kategoria { get; set; }
        public char Status { get; set; }
        public string Tematyka { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Komentarze
    {
        [Key]public int Id_Komentarza { get; set; }
        [ForeignKey("Uzytkownicy")] public int Id_Autora { get; set; }
        [ForeignKey("Wydarzenia")] public int Id_Wydarzenia { get; set; }
        public string Tytul { get; set; }
        public string Tresc { get; set; }       
    }
}

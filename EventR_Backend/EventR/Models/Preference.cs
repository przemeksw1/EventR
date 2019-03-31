using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Preference
    {
        [Key] public int PreferenceId { get; set; }
        [ForeignKey("User")] public int UserId { get; set; }
        public string Type { get; set; }
        public string PreferenceContent { get; set; }
    }
}

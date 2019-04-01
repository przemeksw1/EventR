using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Image
    {
        [Key] public int ImageId { get; set; }
        [ForeignKey("User")] public int AuthorId { get; set; }
        [ForeignKey("Event")] public int EventId { get; set; }
        public string ImageLink { get; set; } //link do grafiki
    }
}

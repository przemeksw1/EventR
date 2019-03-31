using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventRApi.Models
{
    public class Event
    {
        [Key] public int EventId { get; set; }
        [ForeignKey("User")] public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public char State { get; set; }
        public string Subject { get; set; }
    }
}

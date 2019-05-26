using EventR.ViewModels;
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
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Category { get; set; }
        //State
        // T - wydazyl sie
        // F- nie wydazyl sie jeszcze
        public bool State { get; set; }
        public string Subject { get; set; }
        public string ImageMainLink { get; set; }


        public Event()
        { }

        public Event(string name, string description, DateTime dateStart, DateTime dateEnd, string category, bool state, string subject, string image, int authorId)
        {
            AuthorId = authorId;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Category = category;
            State = state;
            Subject = subject;
            ImageMainLink = image;
        }
    }
}

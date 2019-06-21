using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.ViewModels
{
    public class EventViewModel
    {
        
        
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Category { get; set; }
        //State - czy sie juz odbyl
        // true - wydazyl sie
        // false - nie wydazyl sie jeszcze
        public bool State { get; set; }
        public string Subject { get; set; }
        public string ImageMainLink { get; set; }
    }
}

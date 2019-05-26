using EventR.ViewModels;
using EventRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly Context _context;
        public EventService(Context context)
        {
            _context = context;           
        }

        public void AddEvent(EventViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException();
            var newEvent = new Event(viewModel.Name, viewModel.Description, viewModel.DateStart,
                viewModel.DateEnd, viewModel.Category, viewModel.State, viewModel.Subject, viewModel.ImageMainLink,
                viewModel.AuthorId);

           

            _context.events.Add(newEvent);
            _context.SaveChanges();
        }
    }
}

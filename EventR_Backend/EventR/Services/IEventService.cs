using EventR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Services
{
    public interface IEventService
    {
        void AddEvent(EventViewModel viewModel, int authorId);
    }
}

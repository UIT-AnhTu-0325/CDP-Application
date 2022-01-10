using EventService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Core.Interfaces.Services
{
    public interface IEventService
    {
        public Task<IEnumerable<Event>> GetAllEvents();
        public Task<Event> GetEventById(int id);
        public Task<Event> CreateEvent(Event Event);
        public Task<bool> DeleteEvent(int id);
        public Task<Object> UpdateEvent(int id, Event Event);
    }
}

using AutoMapper;
using EventService.Core.Interfaces.Repositories;
using EventService.Core.Models;
using EventService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event = EventService.Core.Models.Event;

namespace EventService.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _dbContext;
        private readonly IMapper _mapper;
        public EventRepository(EventDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Event> CreateEvent(Event Event)
        {
            var dbEvent = _mapper.Map<Entities.Event>(Event);
            await _dbContext.Events.AddAsync(dbEvent);
            await _dbContext.SaveChangesAsync();
            return Event;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var Event = await _dbContext.Events.FindAsync(id);
            if (Event != null)
            {
                _dbContext.Events.Remove(Event);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            var Events = await _dbContext.Events.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Event>>(Events);
        }

        public async Task<Event> GetEventById(int id)
        {
            var Event = await _dbContext.Events.FindAsync(id);
            if(Event != null)
            {
                return _mapper.Map<Event>(Event);
            }
            return null;
        }

        public async Task<Object> UpdateEvent(int id, Event Event)
        {
            var dbEvent = await _dbContext.Events.FindAsync(id);
            if (dbEvent == null)
            {
                return new { message = "Not found!" };
            }
            //if (dbEvent.UpdatedAt != Event.UpdatedAt)
            //{
            //    return new { message = "Event has been updated, please refresh the page!\n",
            //        update = $"{dbEvent.UpdatedAt}\n",
            //        update2 = $"{Event.UpdatedAt}\n"
            //    };
            //}
            dbEvent.Type = Event.Type;
            dbEvent.TimeOfEvent = Event.TimeOfEvent;
            dbEvent.ActionOfEvent = Event.ActionOfEvent;
            dbEvent.IdProfile = Event.IdProfile;
            dbEvent.SourceOfEvent = Event.SourceOfEvent;

            // Update Event
            _dbContext.Events.Update(dbEvent);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", Event = dbEvent };
        }
    }
}

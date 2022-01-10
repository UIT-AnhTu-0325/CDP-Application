using EventService.Core.Interfaces.Repositories;
using EventService.Core.Interfaces.Services;
using EventService.Core.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Core.Services
{
    public class EventService : IEventService
    {
        public readonly IEventRepository _EventRepository;
        private readonly ILogger<EventService> _logger;
        public EventService(IEventRepository EventRepository, ILogger<EventService> logger)
        {
            _EventRepository = EventRepository??throw new ArgumentNullException(nameof(EventRepository));
            _logger = logger??throw new ArgumentNullException(nameof(logger));
        }   
        public async Task<Event> CreateEvent(Event Event)
        {
            try
            {
                return await _EventRepository.CreateEvent(Event);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call CreateEvents in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteEvent(int id)
        {
            try
            {
                return await _EventRepository.DeleteEvent(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call DeleteEvent in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            try
            {
                return await _EventRepository.GetAllEvents();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetAllEvents in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Event> GetEventById(int id)
        {
            try
            {
                return await _EventRepository.GetEventById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetEventById in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Object> UpdateEvent(int id, Event Event)
        {
            try
            {
                return await _EventRepository.UpdateEvent(id, Event);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call UpdateEvent in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}

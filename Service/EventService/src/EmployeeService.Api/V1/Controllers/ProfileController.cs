using EventService.Core.Interfaces.Services;
using EventService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _EventService;  
        public EventController(IEventService EventService)
        {
            _EventService = EventService??throw new ArgumentNullException(nameof(EventService));
        }
        // Get All Events
        // Return List Events
        // Table used: Events
        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var response = await _EventService.GetAllEvents().ConfigureAwait(false);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // Get Event By Id
        // Return an Event by Id
        // Table used: Events
        [HttpGet("{id}", Name = "GetEventById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            var response = await _EventService.GetEventById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        // Create Event
        // Return an Event created`
        // Table used: Events
        [HttpPost(Name = "CreateEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Event>> CreateEvent(Event Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _EventService.CreateEvent(Event).ConfigureAwait(false);
            return CreatedAtRoute(nameof(CreateEvent), new {id = response.Id}, response);
        }

        // Delete Event
        // Return true - false
        // Table used: Events
        [HttpDelete("{id}",Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteEvent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            return await _EventService.DeleteEvent(id).ConfigureAwait(false);
        }

        // Update Event
        // Return true - false
        // Table used: Events
        [HttpPut("{id}", Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateEvent( int id, Event Event)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _EventService.UpdateEvent(id, Event).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

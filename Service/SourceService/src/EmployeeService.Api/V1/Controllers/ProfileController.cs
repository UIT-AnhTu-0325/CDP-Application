using SourceService.Core.Interfaces.Services;
using SourceService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SourceService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private readonly ISourceService _SourceService;  
        public SourceController(ISourceService SourceService)
        {
            _SourceService = SourceService??throw new ArgumentNullException(nameof(SourceService));
        }
        // Get All Sources
        // Return List Sources
        // Table used: Sources
        [HttpGet(Name = "GetAllSources")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Source>>> GetSources()
        {
            var response = await _SourceService.GetAllSources().ConfigureAwait(false);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // Get Source By Id
        // Return an Source by Id
        // Table used: Sources
        [HttpGet("{id}", Name = "GetSourceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Source>> GetSourceById(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            var response = await _SourceService.GetSourceById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        // Create Source
        // Return an Source created`
        // Table used: Sources
        [HttpPost(Name = "CreateSource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Source>> CreateSource(Source Source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _SourceService.CreateSource(Source).ConfigureAwait(false);
            return CreatedAtRoute(nameof(CreateSource), new {id = response.Id}, response);
        }

        // Delete Source
        // Return true - false
        // Table used: Sources
        [HttpDelete("{id}",Name = "DeleteSource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteSource(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            return await _SourceService.DeleteSource(id).ConfigureAwait(false);
        }

        // Update Source
        // Return true - false
        // Table used: Sources
        [HttpPut("{id}", Name = "UpdateSource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateSource( int id, Source Source)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _SourceService.UpdateSource(id, Source).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

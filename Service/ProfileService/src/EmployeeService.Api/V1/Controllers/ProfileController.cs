using ProfileService.Core.Interfaces.Services;
using ProfileService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfileService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _ProfileService;  
        public ProfileController(IProfileService ProfileService)
        {
            _ProfileService = ProfileService??throw new ArgumentNullException(nameof(ProfileService));
        }
        // Get All Profiles
        // Return List Profiles
        // Table used: Profiles
        [HttpGet(Name = "GetAllProfiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var response = await _ProfileService.GetAllProfiles().ConfigureAwait(false);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // Get Profile By Id
        // Return an Profile by Id
        // Table used: Profiles
        [HttpGet("{id}", Name = "GetProfileById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            var response = await _ProfileService.GetProfileById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        // Create Profile
        // Return an Profile created`
        // Table used: Profiles
        [HttpPost(Name = "CreateProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Profile>> CreateProfile(Profile Profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _ProfileService.CreateProfile(Profile).ConfigureAwait(false);
            return CreatedAtRoute(nameof(CreateProfile), new {id = response.Id}, response);
        }

        // Delete Profile
        // Return true - false
        // Table used: Profiles
        [HttpDelete("{id}",Name = "DeleteProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteProfile(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            return await _ProfileService.DeleteProfile(id).ConfigureAwait(false);
        }

        // Update Profile
        // Return true - false
        // Table used: Profiles
        [HttpPut("{id}", Name = "UpdateProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateProfile( int id, Profile Profile)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _ProfileService.UpdateProfile(id, Profile).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

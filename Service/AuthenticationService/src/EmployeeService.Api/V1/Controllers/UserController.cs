using AuthenticationService.Api.Helper;
using AuthenticationService.Core.Interfaces.Services;
using AuthenticationService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.V1.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _AuthenticationService;
        private readonly JwtService _jwtService;
        public UserController(IUserService userService, IAuthenticationService AuthenticationService, JwtService jwtService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _AuthenticationService = AuthenticationService ?? throw new ArgumentNullException(nameof(AuthenticationService));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));

        }

        // Create Employee
        // Return an Employee created`
        // Table used: Employees
        //[HttpPost(Name = "SignUp")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<User>> CreateUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var response = await _userService.CreateUser(user).ConfigureAwait(false);
        //    return CreatedAtRoute(nameof(CreateUser), new { id = response.Id }, response);
        //}

        // SignIn 
        // Return ...`
        // Table used: User, Employee
        [HttpPost("SignIn",Name = "SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> SignIn(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var dbUser = await _userService.GetUserByUsername(user.Username).ConfigureAwait(false);
            if (dbUser == null)
            {
                return Ok("Invalid username");
            }
            if(dbUser.Password != user.Password)
            {
                return Ok("Invalid password");
            }
            var dbEmployee = await _AuthenticationService.GetEmployeeById(dbUser.IdEmployee).ConfigureAwait(false);
            var jwtString = _jwtService.Generate(dbUser.Id);
            HttpContext.Response.Cookies.Append("jwt", jwtString, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.Now.AddMinutes(60),
                IsEssential = true
            });
            return Ok(new
            {
                user = user,
                employee = dbEmployee,
                jwtString = jwtString
            });
        }

        // GetUserByJwt
        // Return ...`
        // Table used: User
        [HttpGet("User", Name = "GetUserByJwt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserByJwt()
        {
            try
            {
                var jwtString = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwtString);
                int userId = int.Parse(token.Issuer);

                var user = await _userService.GetUserById(userId);
                var dbEmployee = await _AuthenticationService.GetEmployeeById(userId).ConfigureAwait(false);


                return Ok(new
                {
                    user = user,
                    employee = dbEmployee
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // SignOut
        // Return ...`
        // Table used: ...
        [HttpPost("SignOut", Name = "SignOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Success!"
            });
        }
    }
}

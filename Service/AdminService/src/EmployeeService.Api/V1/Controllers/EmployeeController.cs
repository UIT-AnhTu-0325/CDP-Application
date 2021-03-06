using AdminService.Core.Interfaces.Services;
using AdminService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IAdminService _AdminService;  
        public EmployeeController(IAdminService AdminService)
        {
            _AdminService = AdminService??throw new ArgumentNullException(nameof(AdminService));
        }
        // Get All Employees
        // Return List Employees
        // Table used: Employees
        [HttpGet(Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var response = await _AdminService.GetAllEmployees().ConfigureAwait(false);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // Get Employee By Id
        // Return an Employee by Id
        // Table used: Employees
        [HttpGet("{id}", Name = "GetEmployeeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            var response = await _AdminService.GetEmployeeById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        // Create Employee
        // Return an Employee created`
        // Table used: Employees
        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _AdminService.CreateEmployee(employee).ConfigureAwait(false);
            return CreatedAtRoute(nameof(CreateEmployee), new {id = response.Id}, response);
        }

        // Delete Employee
        // Return true - false
        // Table used: Employees
        [HttpDelete("{id}",Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            return await _AdminService.DeleteEmployee(id).ConfigureAwait(false);
        }

        // Update Employee
        // Return true - false
        // Table used: Employees
        [HttpPut("{id}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateEmployee( int id, Employee employee)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _AdminService.UpdateEmployee(id, employee).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

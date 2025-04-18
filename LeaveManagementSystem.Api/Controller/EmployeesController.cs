using MediatR;
using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Application.Features.Commands.Employees;
using LeaveManagementSystem.Application.Features.Queries.Employees;
using LeaveManagementSystem.Application.DTOs;

namespace LeaveManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _mediator.Send(query);

            return result != null
                ? Ok(result)
                : NotFound();
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand createDto)
        {
            var command = new CreateEmployeeCommand(
                createDto.FullName,
                createDto.Department,
                createDto.JoiningDate
            );

            var employeeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeId }, employeeId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDTO updateDto)
        {
            var command = new UpdateEmployeeCommand(
                id,
                updateDto.FullName,
                updateDto.Department,
                updateDto.JoiningDate
            );

            var result = await _mediator.Send(command);
            return Ok(result); // Retourne 200 OK avec le message
        }

        // DELETE: api/employees/5
  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result); // Retourne 200 OK avec le message
        }
    }
}
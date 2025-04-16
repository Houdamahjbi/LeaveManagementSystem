using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using LeaveManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public LeaveRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/leaverequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> Get()
        {
            return Ok(await _context.LeaveRequests.ToListAsync());
        }

        // GET: api/leaverequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> Get(int id)
        {
            var request = await _context.LeaveRequests.FindAsync(id);
            return request == null ? NotFound() : Ok(request);
        }

        // POST: api/leaverequests
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> Post([FromBody] LeaveRequest request)
        {
            _context.LeaveRequests.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = request.Id }, request);
        }

        // PUT: api/leaverequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LeaveRequest request)
        {
            if (id != request.Id) return BadRequest();
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/leaverequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.LeaveRequests.FindAsync(id);
            if (request == null) return NotFound();
            _context.LeaveRequests.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
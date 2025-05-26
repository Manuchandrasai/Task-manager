// File: Controllers/TasksController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.Models;

namespace TaskManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    // → routes will be /api/tasks
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TasksController(ApplicationDbContext db) => _db = db;

        // GET /api/tasks
        [HttpGet]
        public async Task<IEnumerable<TaskItem>> Get() =>
            await _db.TaskItems.ToListAsync();

        // POST /api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Post(TaskItem item)
        {
            _db.TaskItems.Add(item);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // GET /api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(int id)
        {
            var item = await _db.TaskItems.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // PUT /api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskItem item)
        {
            if (id != item.Id) return BadRequest();
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.TaskItems.FindAsync(id);
            if (item == null) return NotFound();
            _db.TaskItems.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

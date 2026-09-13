using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class WorkersController : ControllerBase
{
    private readonly AppDbContext db;

    public WorkersController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkers()
    {
        var workers = await db.Workers.ToListAsync();

        return Ok(workers);
    }
    [HttpPost]
    public async Task<IActionResult> AddWorker(Worker worker)
    {
        if (string.IsNullOrWhiteSpace(worker.Name))
        {
            return BadRequest("Name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(worker.PhoneNum))
        {
            return BadRequest("Phone number cannot be empty.");
        }

        if (worker.Salary < 0)
        {
            return BadRequest("Salary cannot be negative.");
        }

        db.Workers.Add(worker);
        await db.SaveChangesAsync();

        return Ok(worker);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorker(int id)
    {
        var worker = await db.Workers.FindAsync(id);

        if (worker == null)
        {
            return NotFound();
        }

        db.Workers.Remove(worker);
        await db.SaveChangesAsync();

        return NoContent();
    }
}
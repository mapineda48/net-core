using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Climate.Models;

namespace Climate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoryController(AppDbContext context) : ControllerBase
{
    // GET: api/History
    [HttpGet]
    public async Task<ActionResult<IEnumerable<History>>> Gethistory()
    {
        return await context.Historys.ToListAsync();
    }

    // GET: api/History/5
    [HttpGet("{id}")]
    public async Task<ActionResult<History>> GetHistory(int id)
    {
        if (id == -1)
        {
            return await PostHistory(new History());
        }

        var history = await context.Historys.FindAsync(id);

        if (history is null)
        {
            return NotFound();
        }

        return history;
    }

    // POST: api/History
    [HttpPost]
    public async Task<ActionResult<History>> PostHistory(History history)
    {
        context.Historys.Add(history);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetHistory), new { id = history.Id }, history);
    }
}

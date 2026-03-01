using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Climate.Models;

namespace Climate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExternalController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> FetchExternalApiAsync(
        [FromHeader(Name = "History-ID")] int historyId,
        [FromQuery] string? location)
    {
        if (historyId < 1)
        {
            return BadRequest("missing header \"History-ID\"");
        }

        if (string.IsNullOrEmpty(location))
        {
            return BadRequest("missing query location");
        }

        var history = await context.Historys.FindAsync(historyId);

        if (history is null)
        {
            return BadRequest("Not Found History");
        }

        var cityData = await context.CityDatas
            .FirstOrDefaultAsync(c => c.CityName == location.ToLower());

        if (cityData is null)
        {
            return NotFound($"City \"{location}\" not found. Available cities: london, new york, tokyo, paris, sydney.");
        }

        using var weather = JsonDocument.Parse(cityData.WeatherJson);
        using var news = JsonDocument.Parse(cityData.NewsJson);

        var result = new { news = news.RootElement.Clone(), weather = weather.RootElement.Clone() };

        context.Locations.Add(new Location { History = history, Name = location });
        await context.SaveChangesAsync();

        return Ok(result);
    }
}

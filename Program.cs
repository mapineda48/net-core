using System.Text.Json.Serialization;
using Climate;
using Climate.Models;
using Microsoft.EntityFrameworkCore;

/*
 * When executing docker-compose up, wait for the database service to be ready.
 */
var delay = Environment.GetEnvironmentVariable("APP_RUN_DELAY");

if (delay is not null)
{
    var time = int.Parse(delay);
    Console.WriteLine($"Sleep {time}");
    await Task.Delay(time);
}

/*
 * Builder Application
 */
var builder = WebApplication.CreateBuilder(args);

/*
 * Services
 */
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddRazorPages();
builder.Services.AddClimateContext();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
 * Initialize database
 */
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
    await SeedData.SeedAsync(db);
}

/*
 * Configure App
 */
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClimateApi v1"));
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();

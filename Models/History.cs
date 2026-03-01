namespace Climate.Models;

public class History
{
    public int Id { get; set; }
    public virtual ICollection<Location> Location { get; set; } = new List<Location>();
}

public class Location
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual History? History { get; set; }
}

public class CityData
{
    public int Id { get; set; }
    public required string CityName { get; set; }
    public required string WeatherJson { get; set; }
    public required string NewsJson { get; set; }
}

using Microsoft.EntityFrameworkCore;

namespace Climate.Models;

public static class SeedData
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.CityDatas.AnyAsync())
            return;

        context.CityDatas.AddRange(
            new CityData
            {
                CityName = "london",
                WeatherJson = """
                {
                    "coord": { "lon": -0.1257, "lat": 51.5085 },
                    "weather": [{ "id": 802, "main": "Clouds", "description": "scattered clouds", "icon": "03d" }],
                    "base": "stations",
                    "main": { "temp": 282.15, "feels_like": 279.80, "temp_min": 280.93, "temp_max": 283.71, "pressure": 1012, "humidity": 72 },
                    "visibility": 10000,
                    "wind": { "speed": 5.14, "deg": 240 },
                    "clouds": { "all": 40 },
                    "dt": 1700000000,
                    "sys": { "type": 2, "id": 2075535, "country": "GB", "sunrise": 1699945200, "sunset": 1699977600 },
                    "timezone": 0,
                    "id": 2643743,
                    "name": "London",
                    "cod": 200
                }
                """,
                NewsJson = """
                {
                    "status": "ok",
                    "totalResults": 3,
                    "articles": [
                        {
                            "source": { "id": "bbc-news", "name": "BBC News" },
                            "author": "BBC News",
                            "title": "London Underground celebrates 160 years of service",
                            "description": "The Tube marks a major milestone as one of the world's oldest metro systems.",
                            "url": "https://www.bbc.co.uk/news/uk-england-london-1",
                            "urlToImage": "https://ichef.bbci.co.uk/news/1024/branded_news/london.jpg",
                            "publishedAt": "2024-01-10T12:00:00Z",
                            "content": "The London Underground has been a vital part of the city's transport network."
                        },
                        {
                            "source": { "id": "the-guardian", "name": "The Guardian" },
                            "author": "The Guardian",
                            "title": "Thames Barrier raised amid flood warnings across London",
                            "description": "The Thames Barrier was raised as heavy rain brought flood warnings.",
                            "url": "https://www.theguardian.com/uk-news/london-flood",
                            "urlToImage": "https://i.guim.co.uk/img/london-barrier.jpg",
                            "publishedAt": "2024-01-09T15:30:00Z",
                            "content": "Authorities raised the Thames Barrier as a precautionary measure."
                        },
                        {
                            "source": { "id": null, "name": "Evening Standard" },
                            "author": "Evening Standard",
                            "title": "New cycling lanes approved for central London",
                            "description": "Mayor approves expanded cycling infrastructure across the capital.",
                            "url": "https://www.standard.co.uk/news/london-cycling",
                            "urlToImage": "https://static.standard.co.uk/cycling.jpg",
                            "publishedAt": "2024-01-08T09:00:00Z",
                            "content": "The new cycling lanes will connect major areas across central London."
                        }
                    ]
                }
                """
            },
            new CityData
            {
                CityName = "new york",
                WeatherJson = """
                {
                    "coord": { "lon": -74.006, "lat": 40.7143 },
                    "weather": [{ "id": 800, "main": "Clear", "description": "clear sky", "icon": "01d" }],
                    "base": "stations",
                    "main": { "temp": 275.37, "feels_like": 271.15, "temp_min": 273.71, "temp_max": 277.04, "pressure": 1025, "humidity": 45 },
                    "visibility": 10000,
                    "wind": { "speed": 7.72, "deg": 310 },
                    "clouds": { "all": 0 },
                    "dt": 1700000000,
                    "sys": { "type": 2, "id": 2037026, "country": "US", "sunrise": 1699962000, "sunset": 1699998000 },
                    "timezone": -18000,
                    "id": 5128581,
                    "name": "New York",
                    "cod": 200
                }
                """,
                NewsJson = """
                {
                    "status": "ok",
                    "totalResults": 3,
                    "articles": [
                        {
                            "source": { "id": "the-new-york-times", "name": "The New York Times" },
                            "author": "NYT Staff",
                            "title": "Broadway season breaks box office records",
                            "description": "The current Broadway season has set new attendance and revenue records.",
                            "url": "https://www.nytimes.com/broadway-records",
                            "urlToImage": "https://static01.nyt.com/images/broadway.jpg",
                            "publishedAt": "2024-01-10T14:00:00Z",
                            "content": "Broadway theaters reported record-breaking ticket sales this season."
                        },
                        {
                            "source": { "id": null, "name": "NY Post" },
                            "author": "NY Post",
                            "title": "Central Park winter festival draws thousands",
                            "description": "Annual winter festival in Central Park attracts record visitors.",
                            "url": "https://nypost.com/central-park-festival",
                            "urlToImage": "https://nypost.com/images/central-park.jpg",
                            "publishedAt": "2024-01-09T11:00:00Z",
                            "content": "The festival features ice skating, food vendors, and live performances."
                        },
                        {
                            "source": { "id": "associated-press", "name": "Associated Press" },
                            "author": "AP",
                            "title": "New subway line extension opens in Manhattan",
                            "description": "The long-awaited subway extension begins service to new neighborhoods.",
                            "url": "https://apnews.com/nyc-subway-extension",
                            "urlToImage": "https://storage.googleapis.com/afs-prod/subway.jpg",
                            "publishedAt": "2024-01-08T08:30:00Z",
                            "content": "Commuters can now access previously underserved areas of Manhattan."
                        }
                    ]
                }
                """
            },
            new CityData
            {
                CityName = "tokyo",
                WeatherJson = """
                {
                    "coord": { "lon": 139.6917, "lat": 35.6895 },
                    "weather": [{ "id": 801, "main": "Clouds", "description": "few clouds", "icon": "02d" }],
                    "base": "stations",
                    "main": { "temp": 280.15, "feels_like": 277.50, "temp_min": 278.71, "temp_max": 281.48, "pressure": 1018, "humidity": 55 },
                    "visibility": 10000,
                    "wind": { "speed": 3.60, "deg": 350 },
                    "clouds": { "all": 20 },
                    "dt": 1700000000,
                    "sys": { "type": 2, "id": 268395, "country": "JP", "sunrise": 1699912800, "sunset": 1699950000 },
                    "timezone": 32400,
                    "id": 1850147,
                    "name": "Tokyo",
                    "cod": 200
                }
                """,
                NewsJson = """
                {
                    "status": "ok",
                    "totalResults": 3,
                    "articles": [
                        {
                            "source": { "id": null, "name": "Japan Times" },
                            "author": "Japan Times",
                            "title": "Tokyo tech startups see record investment in 2024",
                            "description": "Venture capital funding in Tokyo's tech sector reaches an all-time high.",
                            "url": "https://www.japantimes.co.jp/tech-startups",
                            "urlToImage": "https://cdn.japantimes.co.jp/tech.jpg",
                            "publishedAt": "2024-01-10T06:00:00Z",
                            "content": "Tokyo-based startups attracted significant global investment this year."
                        },
                        {
                            "source": { "id": null, "name": "NHK World" },
                            "author": "NHK",
                            "title": "Cherry blossom forecast released for spring season",
                            "description": "Meteorologists predict early blooming across Tokyo this spring.",
                            "url": "https://www3.nhk.or.jp/nhkworld/cherry-blossom",
                            "urlToImage": "https://www3.nhk.or.jp/nhkworld/sakura.jpg",
                            "publishedAt": "2024-01-09T03:00:00Z",
                            "content": "The cherry blossom season is expected to begin earlier than usual."
                        },
                        {
                            "source": { "id": null, "name": "Nikkei Asia" },
                            "author": "Nikkei",
                            "title": "Tokyo Olympic venues find new life as community spaces",
                            "description": "Former Olympic facilities are being repurposed for public use.",
                            "url": "https://asia.nikkei.com/tokyo-venues",
                            "urlToImage": "https://asia.nikkei.com/venues.jpg",
                            "publishedAt": "2024-01-08T07:00:00Z",
                            "content": "Several venues from the 2020 Olympics now serve local communities."
                        }
                    ]
                }
                """
            },
            new CityData
            {
                CityName = "paris",
                WeatherJson = """
                {
                    "coord": { "lon": 2.3488, "lat": 48.8534 },
                    "weather": [{ "id": 500, "main": "Rain", "description": "light rain", "icon": "10d" }],
                    "base": "stations",
                    "main": { "temp": 279.82, "feels_like": 276.90, "temp_min": 278.15, "temp_max": 281.15, "pressure": 1008, "humidity": 85 },
                    "visibility": 8000,
                    "wind": { "speed": 4.12, "deg": 200 },
                    "clouds": { "all": 75 },
                    "dt": 1700000000,
                    "sys": { "type": 2, "id": 2041210, "country": "FR", "sunrise": 1699947600, "sunset": 1699981200 },
                    "timezone": 3600,
                    "id": 2988507,
                    "name": "Paris",
                    "cod": 200
                }
                """,
                NewsJson = """
                {
                    "status": "ok",
                    "totalResults": 3,
                    "articles": [
                        {
                            "source": { "id": null, "name": "France 24" },
                            "author": "France 24",
                            "title": "Paris museums report record visitor numbers",
                            "description": "Major Paris museums including the Louvre see highest attendance in years.",
                            "url": "https://www.france24.com/paris-museums",
                            "urlToImage": "https://s.france24.com/louvre.jpg",
                            "publishedAt": "2024-01-10T10:00:00Z",
                            "content": "The Louvre and Musée d'Orsay both reported significant increases in visitors."
                        },
                        {
                            "source": { "id": null, "name": "Le Monde" },
                            "author": "Le Monde",
                            "title": "New metro line connects Paris suburbs to city center",
                            "description": "The Grand Paris Express project delivers its first new line.",
                            "url": "https://www.lemonde.fr/metro-expansion",
                            "urlToImage": "https://img.lemde.fr/metro.jpg",
                            "publishedAt": "2024-01-09T13:00:00Z",
                            "content": "The new metro line reduces commute times for suburban residents."
                        },
                        {
                            "source": { "id": null, "name": "Reuters" },
                            "author": "Reuters",
                            "title": "Paris prepares green zones ahead of Olympic legacy plan",
                            "description": "The city expands pedestrian-only zones as part of its environmental strategy.",
                            "url": "https://www.reuters.com/paris-green-zones",
                            "urlToImage": "https://www.reuters.com/paris-green.jpg",
                            "publishedAt": "2024-01-08T16:00:00Z",
                            "content": "Several major boulevards will become car-free under the new plan."
                        }
                    ]
                }
                """
            },
            new CityData
            {
                CityName = "sydney",
                WeatherJson = """
                {
                    "coord": { "lon": 151.2093, "lat": -33.8688 },
                    "weather": [{ "id": 800, "main": "Clear", "description": "clear sky", "icon": "01d" }],
                    "base": "stations",
                    "main": { "temp": 298.15, "feels_like": 298.50, "temp_min": 296.48, "temp_max": 300.37, "pressure": 1015, "humidity": 60 },
                    "visibility": 10000,
                    "wind": { "speed": 6.17, "deg": 170 },
                    "clouds": { "all": 5 },
                    "dt": 1700000000,
                    "sys": { "type": 2, "id": 2018875, "country": "AU", "sunrise": 1699904400, "sunset": 1699955400 },
                    "timezone": 39600,
                    "id": 2147714,
                    "name": "Sydney",
                    "cod": 200
                }
                """,
                NewsJson = """
                {
                    "status": "ok",
                    "totalResults": 3,
                    "articles": [
                        {
                            "source": { "id": "abc-news-au", "name": "ABC News (AU)" },
                            "author": "ABC News",
                            "title": "Sydney Harbour Bridge celebrates 90th anniversary",
                            "description": "Celebrations mark nine decades of the iconic Sydney landmark.",
                            "url": "https://www.abc.net.au/news/harbour-bridge-90",
                            "urlToImage": "https://live-production.wcms.abc-cdn.net.au/bridge.jpg",
                            "publishedAt": "2024-01-10T01:00:00Z",
                            "content": "The Sydney Harbour Bridge remains one of Australia's most recognizable landmarks."
                        },
                        {
                            "source": { "id": null, "name": "Sydney Morning Herald" },
                            "author": "SMH",
                            "title": "New ferry routes launched across Sydney Harbour",
                            "description": "Additional ferry services aim to reduce road congestion in the city.",
                            "url": "https://www.smh.com.au/sydney-ferries",
                            "urlToImage": "https://static.ffx.io/ferries.jpg",
                            "publishedAt": "2024-01-09T22:00:00Z",
                            "content": "The new routes connect previously underserved waterfront communities."
                        },
                        {
                            "source": { "id": null, "name": "The Australian" },
                            "author": "The Australian",
                            "title": "Sydney's tech hub Surry Hills attracts global companies",
                            "description": "International tech firms establish offices in Sydney's inner suburbs.",
                            "url": "https://www.theaustralian.com.au/sydney-tech",
                            "urlToImage": "https://content.theaustralian.com.au/tech.jpg",
                            "publishedAt": "2024-01-08T04:00:00Z",
                            "content": "Surry Hills has become a magnet for technology companies seeking APAC presence."
                        }
                    ]
                }
                """
            }
        );

        await context.SaveChangesAsync();
    }
}

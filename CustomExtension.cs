using Climate.Models;
using Microsoft.EntityFrameworkCore;

namespace Climate;

public static class ClimateExtensionMethods
{
    public static IServiceCollection AddClimateContext(this IServiceCollection services)
    {
        var dbStringConnection = Environment.GetEnvironmentVariable("SQLSERVER")
            ?? throw new InvalidOperationException("missing environment variable SQLSERVER");

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseLazyLoadingProxies()
               .UseSqlServer(dbStringConnection));

        return services;
    }
}

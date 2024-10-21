using Location_Finder.Data;
using Location_Finder.Feature;
using Location_Finder.Feature.Providers;
using Microsoft.EntityFrameworkCore;

namespace Location_Finder.WebApplicationExtensions;

public static class WebApplicationExtensions
{
    public static IServiceCollection ConfigureRabbitMQ(this IServiceCollection services)
    {
        return services;
    }
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var configs = configuration.Get<AppSettings>();
        services.Configure<LocatorProviders>(configuration.GetSection("LocatorProviders"));

        services.AddDbContext<LocatorDbContext>(options =>
        {
            if (configs != null)
                options.UseMongoDB(configs.Connection.Host, configs.Connection.DatabaseName);
        });

        services.AddHttpClient();
        services.AddScoped<IIPLocationProvider, IPGeolocationProvider>();
        services.AddScoped<LocationService>();

        return services;
    }
}

using Location_Finder.Data;
using Location_Finder.Feature;
using Location_Finder.Feature.Providers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Location_Finder.WebApplicationExtensions;

public static class Extensions
{
    public static IServiceCollection ConfigureRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        var configs = configuration.Get<AppSettings>();
        if (configs is null) 
        {
            ArgumentNullException.ThrowIfNull(nameof(configs));
        }

        services.AddMassTransit(cfg =>
        {
            var rabbitConfigs = configs.RabbitMqConfiguration;

            cfg.AddConsumers(Assembly.GetExecutingAssembly());

            cfg.UsingRabbitMq((context, config) =>
            {
                config.UseRawJsonDeserializer();
                config.Host(rabbitConfigs.Host, hostConfig =>
                {
                    hostConfig.Username(rabbitConfigs.Username);
                    hostConfig.Password(rabbitConfigs.Password);
                });
                config.ConfigureEndpoints(context);
            });
        });

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

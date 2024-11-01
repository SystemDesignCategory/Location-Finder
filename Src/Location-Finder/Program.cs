using Location_Finder.Feature;
using Location_Finder.WebApplicationExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureRabbitMQ(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
var appGroup = app.MapGroup("/Locations");
appGroup.MapGet("", async (string ip, LocationService locationService) => 
{
    return await locationService.GetLocation(ip);
});

app.Run();
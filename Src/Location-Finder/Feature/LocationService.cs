using Location_Finder.Data;
using Location_Finder.Feature.Providers;
using Microsoft.EntityFrameworkCore;

namespace Location_Finder.Feature;

public class LocationService(IEnumerable<IIPLocationProvider> providers, LocatorDbContext dbContext)
{
    private readonly LocatorDbContext _dbContext = dbContext;
    public async Task<LocationResult> GetLocation(string ip)
    {
        //Read from DB
        var location = await _dbContext.Locations.FirstOrDefaultAsync(c => c.IP == ip);

        if (location != null)
        {
            return new LocationResult
            {
                Location = location
            };
        }

        foreach (var provider in providers)
        {
            var result = await provider.GetLocationAsync(ip);
            if (!result.IsSuccess)
                continue;

            //Save to DB
            _dbContext.Locations.Add(result.Location);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        return new LocationResult
        {
            IsSuccess = false,
            Message = "Not Found",
            Location = new LocationModel
            {                
                IP = ip,
                Country = ""
            }
        };
    }
}
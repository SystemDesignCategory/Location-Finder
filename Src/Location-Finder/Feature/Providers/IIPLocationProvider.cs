namespace Location_Finder.Feature.Providers;

public interface IIPLocationProvider
{
    public Task<LocationResult> GetLocationAsync(string ip);
}

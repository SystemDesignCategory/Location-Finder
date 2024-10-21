
using Microsoft.Extensions.Options;

namespace Location_Finder.Feature.Providers;

public class IPGeolocationProvider(IHttpClientFactory httpClientFactory, IOptions<LocatorProviders> options) : IIPLocationProvider
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly LocatorProviders LocatorProvider = options.Value;
    public async Task<LocationResult> GetLocationAsync(string ip)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(LocatorProvider.IPGeoProvider.URL);
        
        var result = await httpClient.GetAsync($"?apiKey={LocatorProvider.IPGeoProvider.ApiKey}&ip={ip}");

        var locationResponse = await result.Content.ReadFromJsonAsync<LocationResponse>();

        return new LocationResult
        {
            Location = new LocationModel
            {
                IP = ip,
                Country = locationResponse.Country,
            }
        };
    }
}
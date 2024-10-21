using System.Text.Json.Serialization;

namespace Location_Finder.Feature;

public class LocationResponse
{
    [JsonPropertyName("ip")]
    public required string IP { get; set; }

    [JsonPropertyName("continent_code")]
    public string Continent_Code { get; set; }

    [JsonPropertyName("continent_name")]
    public string Continent { get; set; }

    [JsonPropertyName("country_name")]
    public string Country { get; set; }

    [JsonPropertyName("country_capital")]
    public string Country_Capital { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }
}
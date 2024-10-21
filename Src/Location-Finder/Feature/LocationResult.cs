namespace Location_Finder.Feature;

public class LocationResult
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public required LocationModel Location { get; set; }
}

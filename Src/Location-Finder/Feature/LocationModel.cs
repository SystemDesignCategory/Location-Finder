using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Location_Finder.Feature;

[Collection("Locations")]
public class LocationModel
{
    public ObjectId Id { get; set; }
    public required string IP { get; set; }
    public required string Country { get; set; }
    public required string City { get; set; }

}
using Microsoft.EntityFrameworkCore;
using Location_Finder.Feature;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Location_Finder.Data;

public class LocationModelMap : IEntityTypeConfiguration<LocationModel>
{
    public void Configure(EntityTypeBuilder<LocationModel> builder)
    {
        builder.ToCollection("Locations");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}
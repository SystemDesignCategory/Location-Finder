using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Location_Finder.Feature;

namespace Location_Finder.Data;

public partial class LocatorDbContext : DbContext
{
    public DbSet<LocationModel> Locations { get; set; }

    public LocatorDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

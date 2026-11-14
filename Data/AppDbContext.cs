using CargoFlowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoFlowAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Shipment> Shipments => Set<Shipment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shipment>(e =>
        {
            e.Property(s => s.TrackingNumber).HasMaxLength(30).IsRequired();
            e.Property(s => s.Origin).HasMaxLength(100).IsRequired();
            e.Property(s => s.Destination).HasMaxLength(100).IsRequired();
            e.Property(s => s.Status).HasMaxLength(20).IsRequired();
            e.HasIndex(s => s.TrackingNumber).IsUnique();
        });
    }
}

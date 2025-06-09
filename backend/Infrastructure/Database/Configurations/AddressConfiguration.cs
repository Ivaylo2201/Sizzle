using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.CityId);
        builder.HasIndex(a => a.UserId);
        
        builder.HasOne(a => a.City)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.User)
            .WithMany(u => u.Addresses)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
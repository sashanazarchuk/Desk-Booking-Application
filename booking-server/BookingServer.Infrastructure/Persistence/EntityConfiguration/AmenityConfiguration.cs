using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.EntityConfiguration
{
    public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.WorkspaceAmenities)
                   .WithOne(wa => wa.Amenity)
                   .HasForeignKey(wa => wa.AmenityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

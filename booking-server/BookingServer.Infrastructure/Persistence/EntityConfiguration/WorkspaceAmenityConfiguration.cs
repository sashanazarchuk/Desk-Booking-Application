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
    public class WorkspaceAmenityConfiguration : IEntityTypeConfiguration<WorkspaceAmenity>
    {
        public void Configure(EntityTypeBuilder<WorkspaceAmenity> builder)
        {
            builder.HasKey(wa => new { wa.WorkspaceId, wa.AmenityId });

            builder.HasOne(wi => wi.Amenity)
                   .WithMany(i => i.WorkspaceAmenities)
                   .HasForeignKey(wi => wi.AmenityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

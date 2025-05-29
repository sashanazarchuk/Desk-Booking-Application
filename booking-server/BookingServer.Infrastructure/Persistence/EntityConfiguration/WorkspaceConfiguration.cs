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
    public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
    {
        public void Configure(EntityTypeBuilder<Workspace> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Rooms)
                   .WithOne(u => u.Workspace)
                   .HasForeignKey(u => u.WorkspaceId);

            builder.HasMany(w => w.Photos)
                   .WithOne(p => p.Workspace)
                   .HasForeignKey(p => p.WorkspaceId);

            builder.HasMany(w => w.WorkspaceAmenities)
                   .WithOne(wa => wa.Workspace)
                   .HasForeignKey(wa => wa.WorkspaceId);
        }
    }
}
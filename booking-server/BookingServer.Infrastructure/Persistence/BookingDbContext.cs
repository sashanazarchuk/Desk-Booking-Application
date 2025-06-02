using BookingServer.Domain.Entities;
using BookingServer.Infrastructure.Persistence.DataSeed;
using BookingServer.Infrastructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Entity configurations
            modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new AmenityConfiguration());
            modelBuilder.ApplyConfiguration(new WorkspaceAmenityConfiguration());

            //Seeder
            DataSeeder.Seed(modelBuilder);

        }

        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<WorkspaceAmenity> WorkspaceAmenities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<WorkspacePhoto> WorkspacePhotos { get; set; }
    }
}

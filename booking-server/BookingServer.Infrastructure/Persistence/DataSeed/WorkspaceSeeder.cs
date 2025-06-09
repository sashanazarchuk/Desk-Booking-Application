using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class WorkspaceSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workspace>().HasData(

                // Coworking 1 – WorkClub Pechersk
                new Workspace
                {
                    Id = 1,
                    Name = "Open Space",
                    Description = "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease.",
                    CoworkingId = 1
                },

                new Workspace
                {
                    Id = 2,
                    Name = "Private rooms",
                    Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs.",
                    CoworkingId = 1
                },


                // Coworking 2 – UrbanSpace Podil
                new Workspace
                {
                    Id = 3,
                    Name = "Open Space",
                    Description = "Creative and airy shared desks perfect for freelancers.",
                    CoworkingId = 2
                },

                new Workspace
                {
                    Id = 4,
                    Name = "Meeting rooms",
                    Description = "Well-equipped rooms for presentations and brainstorming sessions.",
                    CoworkingId = 2
                },


                // Coworking 3 – Creative Hub Lvivska
                new Workspace
                {
                    Id = 5,
                    Name = "Open Space",
                    Description = "Design-focused open desks with community-driven atmosphere.",
                    CoworkingId = 3
                },

                new Workspace
                {
                    Id = 6,
                    Name = "Private rooms",
                    Description = "Quiet zones ideal for focused work or video calls.",
                    CoworkingId = 3
                },


                // Coworking 4 – TechNest Olimpiiska
                new Workspace
                {
                    Id = 7,
                    Name = "Meeting rooms",
                    Description = "Tech-equipped rooms with whiteboards and screens for workshops.",
                    CoworkingId = 4
                },

                new Workspace
                {
                    Id = 8,
                    Name = "Open Space",
                    Description = "Modern shared desks with fast Wi-Fi and natural light.",
                    CoworkingId = 4
                },


                // Coworking 5 – Hive Station Troieshchyna
                new Workspace
                {
                    Id = 9,
                    Name = "Open Space",
                    Description = "Affordable shared desks with essential amenities.",
                    CoworkingId = 5
                },

                new Workspace
                {
                    Id = 10,
                    Name = "Private rooms",
                    Description = "Comfortable and quiet rooms for individuals or small groups.",
                    CoworkingId = 5
                }
            );
        }
    }
}

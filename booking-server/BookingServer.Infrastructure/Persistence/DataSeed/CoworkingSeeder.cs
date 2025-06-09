using BookingServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Infrastructure.Persistence.DataSeed
{
    public static class CoworkingSeeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coworking>().HasData(

                new Coworking
                {
                    Id = 1,
                    Name = "WorkClub Pechersk",
                    Description = "Modern coworking in the heart of Pechersk with quiet rooms and coffee on tap.",
                    Address = "123 Yaroslaviv Val St, Kyiv",
                    Image= "/images/coworking-1.jpg"
                },

                new Coworking
                {
                    Id = 2,
                    Name = "UrbanSpace Podil",
                    Description = "A creative riverside hub ideal for freelancers and small startups.",
                    Address = "78 Naberezhno-Khreshchatytska St, Kyiv",
                    Image = "/images/coworking-2.jpg"
                },

                new Coworking
                {
                    Id = 3,
                    Name = "Creative Hub Lvivska",
                    Description = "A compact, design-focused space with open desks and strong community vibes.",
                    Address = "12 Lvivska Square, Kyiv",
                    Image = "/images/coworking-3.jpg"
                },


                new Coworking
                {
                    Id = 4,
                    Name = "TechNest Olimpiiska",
                    Description = "A high-tech space near Olimpiiska metro, perfect for team sprints and solo focus.",
                    Address = "45 Velyka Vasylkivska St, Kyiv",
                    Image = "/images/coworking-4.jpg"
                },

                new Coworking
                {
                    Id = 5,
                    Name = "Hive Station Troieshchyna",
                    Description = "A quiet, affordable option in the city's northeast—great for remote workers.",
                    Address = "102 Zakrevskogo St, Kyiv",
                    Image = "/images/coworking-5.jpg"
                }
            );
        }

    }
}

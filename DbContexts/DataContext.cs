
using cappuccino.shifttracker.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            // seed the database with dummy data
            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                Name = "Nursing"
            },

            new Category()
            {
                Id = 2,
                Name = "Yoga"
            },

            new Category()
            {
                Id = 3,
                Name = "Dancing"
            }
            );


            modelBuilder.Entity<Shift>()

            .HasData(
                new Shift()
                {
                    Id = 1,
                    Start = new DateTime(2008, 4, 10, 6, 30, 0),
                    End = new DateTime(2008, 4, 10, 8, 30, 0),
                    CategoryId = 1,
                    LocationId = 1,
                    Money = 300m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 20,
                },

                new Shift()
                {
                    Id = 2,
                    Start = new DateTime(2008, 4, 11, 6, 30, 0),
                    End = new DateTime(2008, 4, 11, 8, 30, 0),
                    CategoryId = 2,
                    LocationId = 2,
                    Money = 300m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 30
                },
                new Shift()
                {
                    Id = 3,
                    Start = new DateTime(2008, 4, 12, 6, 30, 0),
                    End = new DateTime(2008, 4, 12, 8, 30, 0),
                    CategoryId = 3,
                    LocationId = 3,
                    Money = 100m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 40
                },
                 new Shift()
                {
                    Id = 4,
                    Start = new DateTime(2008, 4, 13, 6, 30, 0),
                    End = new DateTime(2008, 4, 13, 8, 30, 0),
                    CategoryId = 3,
                    LocationId = 3,
                    Money = 100m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 40
                },
                 new Shift()
                {
                    Id = 5,
                    Start = new DateTime(2008, 4, 14, 6, 30, 0),
                    End = new DateTime(2008, 4, 14, 8, 30, 0),
                    CategoryId = 2,
                    LocationId = 2,
                    Money = 100m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 40
                },
                 new Shift()
                {
                    Id = 6,
                    Start = new DateTime(2008, 4, 15, 6, 30, 0),
                    End = new DateTime(2008, 4, 15, 8, 30, 0),
                    CategoryId = 1,
                    LocationId = 1,
                    Money = 100m,
                    Duration = new TimeSpan(1, 12, 23, 62),
                    Rate = 40
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

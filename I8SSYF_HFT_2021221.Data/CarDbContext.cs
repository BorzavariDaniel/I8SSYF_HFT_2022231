using I8SSYF_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace I8SSYF_HFT_2021221.Data
{
    public class CarDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<EngineType> EngineTypes { get; set; }
        public virtual DbSet<Verdict> Verdicts { get; set; }

        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasMany(car => car.EngineTypes)
                .WithOne(engine => engine.Car)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Verdict>(entity =>
            {
                entity
                .HasMany(verdict => verdict.EngineTypes)
                .WithOne(engine => engine.Verdict)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EngineType>(entity =>
            {
                entity
                .HasOne(engine => engine.Car)
                .WithMany(car => car.EngineTypes)
                .HasForeignKey(engine => engine.Engine)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(engine => engine.Verdict)
                .WithMany(fuel => fuel.EngineTypes)
                .HasForeignKey(fuel => fuel.EngineCode)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Car car1 = new Car()
            {
                //CarId = 1,
                Engine = "20i",
                Model = "3 series",
                Shape = "Coupe",
                FirstRegistrationDate = 2000,
            };

            Car car2 = new Car()
            {
                //CarId = 2,
                Engine = "40i",
                Model = "5 series",
                Shape = "Sedan",
                FirstRegistrationDate = 2001,
            };

            Car car3 = new Car()
            {
                //CarId = 3,
                Engine = "30d",
                Model = "7 series",
                Shape = "Sedan",
                FirstRegistrationDate = 1998,
            };

            Car car4 = new Car()
            {
                //CarId = 4,
                Engine = "18i",
                Model = "3 series",
                Shape = "Touring",
                FirstRegistrationDate = 1999,
            };

            Verdict verdict1 = new Verdict()
            {
                //VerdictId = 1,
                Reliability = "Very good",
                PowerRating = 6,
                AvgConsumption = 8,
                //EngineCodeFromVerdict = "M54B22"
            };

            Verdict verdict2 = new Verdict()
            {
                //VerdictId = 2,
                Reliability = "Okay",
                PowerRating = 9,
                AvgConsumption = 13,
                //EngineCodeFromVerdict = "M62TUB44"
            };

            Verdict verdict3 = new Verdict()
            {
                //VerdictId = 3,
                Reliability = "Good",
                PowerRating = 7,
                AvgConsumption = 7,
                //EngineCodeFromVerdict = "M57D30"
            };

            Verdict verdict4 = new Verdict()
            {
                //VerdictId = 4,
                Reliability = "Bad",
                PowerRating = 5,
                AvgConsumption = 8,
                //EngineCodeFromVerdict = "N42B20"
            };

            EngineType engine1 = new EngineType()
            {
                //EngineId = 1,
                EngineCode = "M54B22",
                Power = 170,
                NumberOfCylinders = 6,
                Fuel = "Petrol",
                Reliability = verdict1.Reliability,
                Engine = car1.Engine
            };

            EngineType engine2 = new EngineType()
            {
                //EngineId = 2,
                EngineCode = "M62TUB44",
                Power = 286,
                NumberOfCylinders = 8,
                Fuel = "Petrol",
                Reliability = verdict2.Reliability,
                Engine = car2.Engine
            };

            EngineType engine3 = new EngineType()
            {
                //EngineId = 3,
                EngineCode = "M57D30",
                Power = 193,
                NumberOfCylinders = 6,
                Fuel = "Diesel",
                Reliability = verdict3.Reliability,
                Engine = car3.Engine
            };

            EngineType engine4 = new EngineType()
            {
                //EngineId = 4,
                EngineCode = "N42B20",
                Power = 143,
                NumberOfCylinders = 4,
                Fuel = "Petrol",
                Reliability = verdict4.Reliability,
                Engine = car4.Engine
            };

            modelBuilder.Entity<Car>().HasData(car1, car2, car3,car4);
            modelBuilder.Entity<EngineType>().HasData(engine1, engine2, engine3, engine4);
            modelBuilder.Entity<Verdict>().HasData(verdict1, verdict2, verdict3, verdict4);
        }
    }
}

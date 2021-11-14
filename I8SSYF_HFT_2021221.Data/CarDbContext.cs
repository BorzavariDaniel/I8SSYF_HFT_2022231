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
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }

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
            modelBuilder.Entity<Engine>(entity =>
            {
                entity
                .HasOne(engine => engine.Car)
                .WithMany(car => car.Engines)
                .HasForeignKey(engine => engine.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity
                .HasOne(model => model.Car)
                .WithMany(car => car.Models)
                .HasForeignKey(model => model.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Car car1 = new Car() { Id = 1, Name = "BMW 530i", Price = 3000000 };
            Car car2 = new Car() { Id = 2, Name = "BMW 330d", Price = 2500000 };
            Car car3 = new Car() { Id = 3, Name = "BMW 750i", Price = 4000000 };
            Car car4 = new Car() { Id = 4, Name = "BMW 525d", Price = 2000000 };
            Car car5 = new Car() { Id = 5, Name = "BMW 740i", Price = 5000000 };

            Model model1 = new Model() { Id = 1, CarId = car1.Id, Shape = "Sedan" };
            Model model2 = new Model() { Id = 2, CarId = car2.Id, Shape = "Coupe" };
            Model model3 = new Model() { Id = 3, CarId = car3.Id, Shape = "Sedan" };
            Model model4 = new Model() { Id = 4, CarId = car4.Id, Shape = "Touring" };
            Model model5 = new Model() { Id = 5, CarId = car5.Id, Shape = "Sedan" };

            Engine engine1 = new Engine() { Id = 1, CarId = car1.Id, Fuel = "Petrol", NumOfCylinders = 6 };
            Engine engine2 = new Engine() { Id = 2, CarId = car2.Id, Fuel = "Diesel", NumOfCylinders = 6 };
            Engine engine3 = new Engine() { Id = 3, CarId = car3.Id, Fuel = "Petrol", NumOfCylinders = 12 };
            Engine engine4 = new Engine() { Id = 4, CarId = car4.Id, Fuel = "Diesel", NumOfCylinders = 6 };
            Engine engine5 = new Engine() { Id = 5, CarId = car5.Id, Fuel = "Petrol", NumOfCylinders = 8 };


            modelBuilder.Entity<Car>().HasData(car1, car2, car3, car4, car5);
            modelBuilder.Entity<Model>().HasData(model1, model2, model3, model4, model5);
            modelBuilder.Entity<Engine>().HasData(engine1, engine2, engine3, engine4, engine5);
        }
    }
}

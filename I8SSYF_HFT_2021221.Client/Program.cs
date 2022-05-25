using I8SSYF_HFT_2021221.Data;
using I8SSYF_HFT_2021221.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using ConsoleTools;

namespace I8SSYF_HFT_2021221.Client
{
    class Program
    {
        static RestService restService;

        static void Create(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Enter car Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter car name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter car price: ");
                int price = int.Parse(Console.ReadLine());
                restService.Post(new Car() { Id = id, Name = name, Price = price }, "car");
            }
            else if (entity == "Model")
            {
                Console.WriteLine("Enter model shape");
                string shape = Console.ReadLine();
                restService.Post(new Model() { Shape = shape }, "model");
            }
            else if (entity == "Engine")
            {
                Console.WriteLine("Enter engine's number of cylinders: ");
                int numOfCylinders = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter fuel type: ");
                string fuel = Console.ReadLine();
                restService.Post(new Engine() { NumOfCylinders = numOfCylinders, Fuel = fuel }, "engine");
            }
        }

        static void List(string entity)
        {
            if (entity == "Car")
            {
                List<Car> cars = restService.Get<Car>("car");
                foreach (var car in cars)
                {
                    Console.WriteLine($"Id: {car.Id}, Name: {car.Name}, Price: {car.Price}");
                }
            }
            else if (entity == "Model")
            {
                List<Model> models = restService.Get<Model>("model");
                foreach (var model in models)
                {
                    Console.WriteLine($"Id: {model.ModelId}, Shape: {model.Shape}");
                }
            }
            else if (entity == "Engine")
            {
                List<Engine> engines = restService.Get<Engine>("engine");
                foreach (var engine in engines)
                {
                    Console.WriteLine($" Id: {engine.EngineId}, Number of cylinders: {engine.NumOfCylinders}, Fuel: {engine.Fuel}");
                }
            }
            Console.ReadLine();
        }

        static void SplitDatas(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Endter car's data: ");
                int id = int.Parse(Console.ReadLine());
                Car oneData = restService.Get<Car>(id, "car");
                Console.WriteLine($"Id: {oneData.Id}, Name: {oneData.Name}");
            }
            else if (entity == "Model")
            {
                Console.WriteLine("Endter model's data: ");
                int id = int.Parse(Console.ReadLine());
                Model oneData = restService.Get<Model>(id, "model");
                Console.WriteLine($"Id: {oneData.ModelId}, Shape: {oneData.Shape}");
            }
            else if (entity == "Engine")
            {
                Console.WriteLine("Endter engine's data: ");
                int id = int.Parse(Console.ReadLine());
                Engine oneData = restService.Get<Engine>(id, "engine");
                Console.WriteLine($"Id: {oneData.EngineId}, Number of cylinders: {oneData.NumOfCylinders}, Fuel: {oneData.Fuel}");
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Enter the Id of the car: ");
                int id = int.Parse(Console.ReadLine());
                Car oneData = restService.Get<Car>(id, "car");
                Console.WriteLine($"New name of {oneData.Name}: ");
                string name = Console.ReadLine();
                oneData.Name = name;
                restService.Put(oneData, "car");
            }
            else if (entity == "Model")
            {
                Console.WriteLine("Enter the Id of the model: ");
                int id = int.Parse(Console.ReadLine());
                Model oneData = restService.Get<Model>(id, "model");
                Console.WriteLine($"New shape of {oneData.Shape}: ");
                string shape = Console.ReadLine();
                oneData.Shape = shape;
                restService.Put(oneData, "model");
            }
            else if (entity == "Engine")
            {
                Console.WriteLine("Enter the Id of the engine: ");
                int id = int.Parse(Console.ReadLine());
                Engine oneData = restService.Get<Engine>(id, "engine");
                Console.WriteLine($"New Id of {oneData.NumOfCylinders}, {oneData.Fuel}: ");
                string fuel = Console.ReadLine();
                oneData.Fuel = fuel;
                restService.Put(oneData, "engine");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Enter the Id of the car: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "car");
            }
            else if (entity == "Model")
            {
                Console.WriteLine("Enter the Id of the model: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "model");
            }
            else if (entity == "Engine")
            {
                Console.WriteLine("Enter the Id of the engine: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "engine");
            }
            else
            {
                Console.WriteLine("Invalid Id.");
            }
            Console.ReadLine();
        }

        static void AveragePriceByModels()
        {
            List<KeyValuePair<string, double>> list = restService.Get<KeyValuePair<string, double>>("averagePriceByModels");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} -> Average price: {item.Value}");
            }
            Console.ReadLine();
        }
        static void AverageNumberOfCylindersByModels()
        {
            List<KeyValuePair<string, double>> list = restService.Get<KeyValuePair<string, double>>("averageNumberOfCylindersByModels");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} -> Average number of cylinders: {item.Value}");
            }
            Console.ReadLine();
        }

        static void SumPriceByModels()
        {
            List<KeyValuePair<string, double>> list = restService.Get<KeyValuePair<string, double>>("sumPriceByModels");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} -> Sum price: {item.Value}");
            }
            Console.ReadLine();
        }

        static void CarCountByModels()
        {
            List<KeyValuePair<string, double>> list = restService.Get<KeyValuePair<string, double>>("averagePriceByModels");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} -> Count of the cars: {item.Value}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            restService = new RestService("http://localhost:64139/", "car");

            var carMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("SplitDatas", () => List("Car"))
                .Add("Create", () => List("Car"))
                .Add("Update", () => List("Car"))
                .Add("Delete", () => List("Car"))
                .Add("Exit", ConsoleMenu.Close);
        }
    }
}

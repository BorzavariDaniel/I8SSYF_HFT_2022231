using I8SSYF_HFT_2021221.Models;
using I8SSYF_HFT_2021221.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using I8SSYF_HFT_2021221.Repository;

namespace I8SSYF_HFT_2021221.Test
{
    [TestFixture]
    public class LogicTest
    {
        CarLogic carLogic;
        //ModelLogic modelLogic;
        //EngineLogic engineLogic;

        [SetUp]
        public void Setup()
        {
            Mock<ICarRepository> mockCarRepo = new Mock<ICarRepository>();
            Mock<IModelRepository> mockModelRepo = new Mock<IModelRepository>();
            Mock<IEngineRepository> mockEngineRepo = new Mock<IEngineRepository>();

            Model model1 = new Model() { Shape = "Sedan" };
            Model model2 = new Model() { Shape = "Touring" };
            Model model3 = new Model() { Shape = "Coupe" };

            Engine engine1 = new Engine() {Fuel = "Petrol", NumOfCylinders = 6 };
            Engine engine2= new Engine() { Fuel = "Diesel", NumOfCylinders = 6 };
            Engine engine3 = new Engine() { Fuel = "Petrol", NumOfCylinders = 8};


            mockCarRepo.Setup(x => x.ReadAll()).Returns(new List<Car>
            {
                new Car()
                {
                    Price = 3000000,
                    Model = model1,
                    Engine = engine1
                },
                new Car()
                {
                    Price = 2500000,
                    Model = model2,
                    Engine = engine2
                },
                new Car()
                {
                    Price = 4000000,
                    Model = model1,
                    Engine = engine1
                },
                new Car()
                {
                    Price = 2000000,
                    Model = model3,
                    Engine = engine3
                },
            }.AsQueryable());

            carLogic = new CarLogic(mockCarRepo.Object);
        }

        [Test]
        public void TestAveragePrice()
        {
            double avg = carLogic.AveragePrice();
            Assert.That(avg, Is.EqualTo(2875000));
        }

        [Test]
        public void TestAverageNumberOfCylindersByModels()
        {
            var result = carLogic.AverageNumberOfCylindersByModels();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Sedan", 6),
                new KeyValuePair<string, double>("Touring", 6),
                new KeyValuePair<string, double>("Coupe", 8)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestPetrolCars()
        {
            var result = carLogic.PetrolCars();
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void TestAveragePriceByModels()
        {
            var result = carLogic.AveragePriceByModels().ToList();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Sedan", 3500000),
                new KeyValuePair<string, double>("Touring", 2500000),
                new KeyValuePair<string, double>("Coupe", 2000000)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestSedanCount()
        {
            var result = carLogic.SedanCount();

            Assert.That(result, Is.EqualTo(2));
        }
    }
}

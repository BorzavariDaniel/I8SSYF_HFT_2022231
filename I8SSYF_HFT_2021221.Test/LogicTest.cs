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


            mockCarRepo.Setup(x => x.ReadAll()).Returns(new List<Car>
            {
                new Car()
                {
                    Price = 3000000,
                    Model = model1
                },
                new Car()
                {
                    Price = 2500000,
                    Model = model2
                },
                new Car()
                {
                    Price = 4000000,
                    Model = model1
                },
                new Car()
                {
                    Price = 2000000,
                    Model = model3
                },
            }.AsQueryable());

            carLogic = new CarLogic(mockCarRepo.Object);

            mockEngineRepo.Setup(x => x.ReadAll()).Returns(new List<Engine>
            {
                new Engine()
                {
                    Fuel = "Petrol",
                    NumOfCylinders = 6
                },

                new Engine()
                {
                    Fuel = "Diesel",
                    NumOfCylinders = 6
                },

                new Engine()
                {
                    Fuel = "Petrol",
                    NumOfCylinders = 8
                },
            }.AsQueryable()); 
        }

        [Test]
        public void TestAveragePrice()
        {
            double avg = carLogic.AveragePrice();
            Assert.That(avg, Is.EqualTo(2875000));
        }

        [Test]
        public void Test2()
        {
            var result = carLogic.AveragePrice();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test3()
        {
            var result = carLogic.AveragePriceByModels().ToList();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test4()
        {

        }

        [Test]
        public void Test5()
        {
            //Act

            //Assert
        }
    }
}

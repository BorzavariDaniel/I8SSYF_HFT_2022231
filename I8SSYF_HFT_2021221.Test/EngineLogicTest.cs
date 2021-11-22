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
    public class EngineLogicTest
    {
        IEngineLogic engineLogic;

        [SetUp]
        public void Setup()
        {
            Mock<IEngineRepository> mockRepo = new Mock<IEngineRepository>();

            Car car1 = new Car() { Name = "BMW 530i" };
            Car car2 = new Car() { Name = "BMW 330d" };
            Car car3 = new Car() { Name = "BMW 750i" };

            mockRepo.Setup(x => x.ReadAll()).Returns(new List<Engine>
            {
                new Engine()
                {
                    NumOfCylinders = 6,
                    Car = car1
                },
                new Engine()
                {
                    NumOfCylinders = 12,
                    Car = car1
                },
                new Engine()
                {
                    NumOfCylinders = 4,
                    Car = car2
                },
                new Engine()
                {
                    NumOfCylinders = 6,
                    Car = car2
                },
                new Engine()
                {
                    NumOfCylinders = 8,
                    Car = car3
                },
                new Engine()
                {
                    NumOfCylinders = 12,
                    Car = car3
                },
            }.AsQueryable());

            engineLogic = new EngineLogic(mockRepo.Object);
        }

        [Test]
        public void TestAverageNumberCylinders()
        {
            double avg = engineLogic.AverageNumberOfCylinders();
            Assert.That(avg, Is.EqualTo(8));
        }

        [Test]
        public void Test2()
        {
            //Act

            //Assert
        }

        [Test]
        public void Test3()
        {
            //Act

            //Assert
        }

        [Test]
        public void Test4()
        {
            //Act

            //Assert
        }

        [Test]
        public void Test5()
        {
            //Act

            //Assert
        }
    }
}

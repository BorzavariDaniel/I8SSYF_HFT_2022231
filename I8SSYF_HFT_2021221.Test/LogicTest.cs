﻿using I8SSYF_HFT_2021221.Models;
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
        ICarLogic logic;

        [SetUp]
        public void Setup()
        {
            Mock<ICarRepository> mockRepo = new Mock<ICarRepository>();

            Model model1 = new Model() { Shape = "Sedan" };
            Model model2 = new Model() { Shape = "Touring" };
            Model model3 = new Model() { Shape = "Coupe" };


            mockRepo.Setup(x => x.ReadAll()).Returns(new List<Car>
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

            logic = new CarLogic(mockRepo.Object);
        }

        [Test]
        public void TestAveragePrice()
        {
            double avg = logic.AveragePrice();
            Assert.That(avg, Is.EqualTo(2875000));
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

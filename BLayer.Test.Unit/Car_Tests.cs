using System;
using System.Collections.Generic;
using BLayer.Implementations;
using BLayer.Interfaces;
using DBL;
using Domain.Models;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

/**
 * TODO:
 * Починить ситуацию с Category_ID:
 ** Добавить moq наверно
 */

namespace BLayer.Test.Unit
{
    [TestFixture]
    public class Car_Tests
    {
        Car test_car;
        Car test_new_car;
        ICarService service { get; set; }
        int car_ID = 0;

        [SetUp]
        public void Setup()
        {
            test_car = new Car()
            {
                Name = "Test_CAR",
                Desc = "The uniq car for testing the services",
                Price = 100,
                Available = true,
                CategoryID = 4
            };

            test_new_car = new Car()
            {
                Name = "Test_NEW_CAR",
                Desc = "The new uniq car for testing the services",
                Price = 200,
                Available = true,
                CategoryID = 4
            };

            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DBL"));

            var context =  new AppDBContext(optionsBuilder.Options);
            service = new CarService(context);
        }

        [Test]
        public void Create_Successed_Test()
        {
            var created_car = service.Add(test_car);
            bool check = false;

            if (created_car != null)
            {
                car_ID = created_car.ID;
                check = created_car.Name == test_car.Name &&
                    created_car.Desc == test_car.Desc &&
                    created_car.Price == test_car.Price &&
                    created_car.Available == test_car.Available &&
                    created_car.CategoryID == test_car.CategoryID;

                if (check)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
            else
            {
                    Assert.Fail();
            }
        }

        [Test]
        public void Create_Failed_Test()
        {
            try {
                Car new_car = new Car()
                {
                    ID = 1,
                    Name = "Test_NEW_CAR",
                    Desc = "The new uniq car for testing the services",
                    Price = 200,
                    Available = true,
                    CategoryID = 4
                };
                service.Add(new_car);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        //[Test]
        //public void Read_All_Successed_Test()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Read_All_Failed_Test()
        //{
        //    Assert.Pass();
        //}

        [Test]
        public void Read_Successed_Test()
        {
            var recived_car = service.Get(car_ID);

            bool check = false;

            if (recived_car != null)
            {
                check = recived_car.Name == test_car.Name &&
                    recived_car.Desc == test_car.Desc &&
                    recived_car.Price == test_car.Price &&
                    recived_car.Available == test_car.Available &&
                    recived_car.CategoryID == test_car.CategoryID;

                if (check)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
            else
            {
                    Assert.Fail();
            }
        }

        [Test]
        public void Read_Failed_Test()
        {
            var recived_car = service.Get(0);

            if (recived_car == null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Update_Successed_Test()
        {
            service.Update(car_ID, test_new_car);

            var recived_car = service.Get(car_ID);

            bool check = false;

            if (recived_car != null)
            {
                check = recived_car.Name == test_new_car.Name &&
                    recived_car.Desc == test_new_car.Desc &&
                    recived_car.Price == test_new_car.Price &&
                    recived_car.Available == test_new_car.Available &&
                    recived_car.CategoryID == test_new_car.CategoryID;

                if (check)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
            else
            {
                    Assert.Fail();
            }
        }

        [Test]
        public void Update_Failed_Test()
        {
            try {service.Update(0, test_new_car); }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void Delete_Successed_Test()
        {
            service.Delete(car_ID);
            var recived_car = service.Get(car_ID);

            if (recived_car == null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Delete_Failed_Test()
        {
            try
            {
                service.Delete(0);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
                Assert.Fail();
        }
    }
}
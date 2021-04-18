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
using System.Linq;

/**
 * TODO:
 * Починить ситуацию с Category_ID:
 ** Добавить moq наверно
 */

namespace BLayer.Test.Unit
{
    [TestFixture]
    class Category_Tests
    {
        Category test_category;
        Category test_new_category;
        ICategoryService service { get; set; }
        int category_ID = 0;

        [SetUp]
        public void Setup()
        {
            test_category = new Category()
            {
                Name = "Test_CATEGORY",
                Desc = "The uniq category for testing the services",
                Cars = new List<Car>()
            };

            test_new_category = new Category()
            {
                Name = "Test_NEW_CATEGORY",
                Desc = "The new uniq category for testing the services",
                Cars = new List<Car>()
            };

            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DBL"));

            var context = new AppDBContext(optionsBuilder.Options);
            service = new CategoryService(context);

            //category_ID = service.Get(1).ID;
        }

        [Test]
        public void Create_Successed_Test()
        {
            var created_category = service.Add(test_category);
            bool check = false;

            if (created_category != null)
            {
                check = created_category.Name == test_category.Name &&
                    created_category.Desc == test_category.Desc &&
                    created_category.Cars.SequenceEqual(test_category.Cars);

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
            try
            {
                Category new_category = new Category()
                {
                    ID = 1,
                    Name = "Test_NEW_CATEGORY",
                    Desc = "The new uniq category for testing the services",
                    Cars = new List<Car>()
                };
                service.Add(new_category);
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
            var recived_category = service.Get(category_ID);

            bool check = false;

            if (recived_category != null)
            {
                check = recived_category.Name == test_category.Name &&
                    recived_category.Desc == test_category.Desc &&
                    recived_category.Cars.SequenceEqual(recived_category.Cars); // Warning!

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
            var recived_category = service.Get(0);

            if (recived_category == null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Update_Successed_Test()
        {
            service.Update(category_ID, test_new_category);

            var recived_category = service.Get(category_ID);

            bool check = false;

            if (recived_category != null)
            {
                check = recived_category.Name == test_new_category.Name &&
                    recived_category.Desc == test_new_category.Desc &&
                    recived_category.Cars.SequenceEqual(recived_category.Cars); // Warning!

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
            try { service.Update(0, test_new_category); }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void Delete_Successed_Test()
        {
            service.Delete(category_ID);
            var recived_category = service.Get(category_ID);

            if (recived_category == null)
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

using System;
using OdeToFood.Controllers;
using OdeToFood.Models;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Web.Mvc;
using NUnit.Framework;

namespace OdeToFood.Test
{
    [TestFixture]
    public class UnitTest1
    {
        public IRestaurantData tdb;
        
        [SetUp]
        public void InitializeTestDatabase()
        {
            tdb = new InMemoryRestaurantData();
            var restaurant = new Restaurant { Id = 1, CreateDate = new DateTime(2020, 1, 1), Cuisine = CuisineType.Italian, Name = "Scott's Pizza" };
            var restaurant2 = new Restaurant { Id = 2, CreateDate = new DateTime(2018, 1, 1), Cuisine = CuisineType.Indian, Name = "Taj Mahal" };
            tdb.Add(restaurant);
            tdb.Add(restaurant2);
        }

        [TearDown]
        public void DisposeTestDatabase()
        {
            tdb = null;
        }

        [Test]
        public void TestAdd()
        {
            InitializeTestDatabase();
            Restaurant restaurant = new Restaurant { Id = 1, CreateDate = new DateTime(2020, 1, 1), Cuisine = CuisineType.Italian, Name = "Scott's Pizza" };
            var restaurant2 = tdb.Get(1);
            Assert.AreEqual(restaurant.Name, restaurant2.Name);
            DisposeTestDatabase();
        }
        [Test]
        public void TestGet()
        {
            InitializeTestDatabase();
            var restaurant = tdb.Get(1);
            Assert.AreEqual(restaurant.Name, "Scott's Pizza");
            DisposeTestDatabase();
        }

        [Test]
        public void TestDelete()
        {
            InitializeTestDatabase();
            tdb.Delete(1);
            Assert.AreEqual(tdb.Get(1), null);
            DisposeTestDatabase();
        }

        [Test]
        public void TestUpdate()
        {
            InitializeTestDatabase();
            var restaurant =  new Restaurant { Id = 1, CreateDate = new DateTime(2020, 1, 1), Cuisine = CuisineType.Italian, Name = "lol" };
            tdb.Update(restaurant);
            Assert.AreEqual(tdb.Get(1).Name, "lol");
            DisposeTestDatabase();
        }

        [Test]
        public void Test1()
        {
            int a = 1;
            int b = 2;
            Assert.That(a < b);
        }
    }
}

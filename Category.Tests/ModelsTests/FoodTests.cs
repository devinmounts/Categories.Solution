using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Categories.Models;

namespace Categories.Tests
{
    [TestClass]
    public class CategoryTests : IDisposable
    {
        public void Dispose()
        {
            Food.DeleteAll();
        }
        public void FoodTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=relations;";
        }

        [TestMethod]
        public void GetSetName_SetsGetsName_String()
        {
            Food newFood = new Food(1, 2,  "apple");

            Assert.AreEqual("apple", newFood.GetName());
        }

        [TestMethod]
        public void GetSetId_SetsGetsId_Int()
        {
            Food newFood = new Food(1, 2, "apple");

            Assert.AreEqual(1, newFood.GetId());
        }

        [TestMethod]
        public void GetSetCategoryId_SetsGetsCategoryId_Id()
        {
            Food newFood = new Food(1, 2, "apple");

            Assert.AreEqual(2, newFood.GetCategoryId());

        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Food.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSameIds_Bool()
        {
            Food firstFood = new Food(1, 2, "apple");
            Food secondFood = new Food(1, 2, "apple");

            Assert.AreEqual(firstFood, secondFood);
        }

        [TestMethod]
        public void Save_SaveFoodToDatabase_FoodList()
        {
            Food testFood = new Food(1, 2, "apple");

            testFood.Save();
            List<Food> result = Food.GetAll();
            List<Food> testList = new List<Food> { testFood };

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Food testFood = new Food(1, 2, "apple");

            testFood.Save();
            Food savedFood = Food.GetAll()[0];

            int result = savedFood.GetId();
            int testId = testFood.GetId();

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FinsIdOfObject_Id()
        {
            Food testFood = new Food(1, 2, "apple");

            testFood.Save();
            Food savedFood = Food.Find(1);

            int result = savedFood.GetId();
            int testId = testFood.GetId();

            Assert.AreEqual(testId, result);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Categories.Models;

namespace Categories.Tests.ModelsTests
{
    [TestClass]
    public class CategoryTests : IDisposable
    {
        public void Dispose()
        {
            Category.DeleteAll();
            Category.DeleteAll();
        }

        public CategoryTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=relations_test;";
        }

        [TestMethod]
        public void GetAll_CategoriesEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Category.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForSameName_Category()
        {
            //Arrange, Act
            Category firstCategory = new Category("vegetables");
            Category secondCategory = new Category("vegetables");

            //Assert
            Assert.AreEqual(firstCategory, secondCategory);
        }

        [TestMethod]
        public void Save_SavesCategoryToDatabase_CategoryList()
        {
            //Arrange
            Category testCategory = new Category("vegetables");
            testCategory.Save();

            //Act
            List<Category> result = Category.GetAll();
            List<Category> testList = new List<Category> { testCategory };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }


        [TestMethod]
        public void Save_DatabaseAssignsIdToCategory_Id()
        {
            //Arrange
            Category testCategory = new Category("vegetables");
            testCategory.Save();

            //Act
            Category savedCategory = Category.GetAll()[0];

            int result = savedCategory.GetId();
            int testId = testCategory.GetId();

            //Assert
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsCategoryInDatabase_Category()
        {
            //Arrange
            Category testCategory = new Category("vegetables");
            testCategory.Save();

            //Act
            Category foundCategory = Category.Find(testCategory.GetId());

            //Assert
            Assert.AreEqual(testCategory, foundCategory);
        }
    }
}
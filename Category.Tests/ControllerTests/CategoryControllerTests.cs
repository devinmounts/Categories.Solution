using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Categories.Controllers;
using Categories.Models;

namespace Categories.Tests.ControllerTests
{
    [TestClass]
    public class CategoryControllerTests : IDisposable
    {
        public void Dispose()
        {
            Category.DeleteAll();
        }

        [TestMethod]
        public void Search_ReturnsCorrectView_True()
        {
            CategoryController controller = new CategoryController();
            ActionResult searchView = controller.Search();
            Assert.IsInstanceOfType(searchView, typeof(ViewResult));
        }

        [TestMethod]
        public void Add_ReturnsCorrectView_True()
        {
            CategoryController controller = new CategoryController();
            ActionResult addView = controller.Add("apple", 1);
            Assert.IsInstanceOfType(addView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void UpdateForm_ReturnsCorrectView_True()
        {
            CategoryController controller = new CategoryController();
            ActionResult updateView = controller.UpdateForm(1);
            Assert.IsInstanceOfType(updateView, typeof(ViewResult));
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            CategoryController controller = new CategoryController();
            ActionResult allView = controller.All();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_HasCorrectModelType_Category()
        {
            ViewResult resultsView = new CategoryController().Results(1, "Apple") as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Category>));
        }

    }
}

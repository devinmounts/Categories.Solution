using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Categories.Controllers;
using Categories.Models;

namespace Categories.Tests.ControllerTests
{
    [TestClass]
    public class FoodControllerTests : IDisposable
    {
        public void Dispose()
        {
            Food.DeleteAll();
        }

        [TestMethod]
        public void Search_ReturnsCorrectView_True()
        {
            FoodController controller = new FoodController();
            ActionResult searchView = controller.Search();
            Assert.IsInstanceOfType(searchView, typeof(ViewResult));
        }

        [TestMethod]
        public void Add_ReturnsCorrectView_True()
        {
            FoodController controller = new FoodController();
            ActionResult addView = controller.Add(1, "apple");
            Assert.IsInstanceOfType(addView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void UpdateForm_ReturnsCorrectView_True()
        {
            FoodController controller = new FoodController();
            ActionResult updateView = controller.UpdateForm(1);
            Assert.IsInstanceOfType(updateView, typeof(ViewResult));
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            FoodController controller = new FoodController();
            ActionResult allView = controller.All();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_HasCorrectModelType_Food()
        {
            ViewResult resultsView = new FoodController().Results(1, 2, "Apple") as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Food>));
        }

    }
}

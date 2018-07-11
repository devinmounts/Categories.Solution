using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Categories.Controllers;
using Categories.Models;

namespace Categories.Tests.ControllerTests
{
    [TestClass]
    public class DataControllerTests : IDisposable
    {
        public void Dispose()
        {
            Food.DeleteAll();
        }

        [TestMethod]
        public void Search_ReturnsCorrectView_True()
        {
            DataController controller = new DataController();
            ActionResult searchView = controller.Search();
            Assert.IsInstanceOfType(searchView, typeof(ViewResult));
        }

        [TestMethod]
        public void Add_ReturnsCorrectView_True()
        {
            DataController controller = new DataController();
            ActionResult addView = controller.Add();
            Assert.IsInstanceOfType(addView, typeof(ViewResult));
        }

        [TestMethod]
        public void UpdateForm_ReturnsCorrectView_True()
        {
            DataController controller = new DataController();
            ActionResult updateView = controller.UpdateForm(1);
            Assert.IsInstanceOfType(updateView, typeof(ViewResult));
        }

        [TestMethod]
        public void All_ReturnsCorrectView_True()
        {
            DataController controller = new DataController();
            ActionResult allView = controller.All();
            Assert.IsInstanceOfType(allView, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_HasCorrectModelType_Food()
        {
            ViewResult resultsView = new DataController().Results(1, 2, "Apple") as ViewResult;
            var result = resultsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Food>));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Categories.Controllers;
using Categories.Models;

namespace Categories.Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests : IDisposable
    {
        public void Dispose()
        {
            Food.DeleteAll();
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult formView = controller.Index();
            Assert.IsInstanceOfType(formView, typeof(ViewResult));
        }

    }
}

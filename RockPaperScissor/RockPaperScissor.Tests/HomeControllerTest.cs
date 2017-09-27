using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using RockPaperScissor;
using RockPaperScissor.Controllers;
namespace RockPaperScissor.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController _home = new HomeController();

            ViewResult result = _home.Index() as ViewResult;

            Assert.AreEqual("Waste an hour by having Fun", result.ViewBag.HomeTitle);
        }
    }
}

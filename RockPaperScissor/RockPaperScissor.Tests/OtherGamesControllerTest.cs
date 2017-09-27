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
    public class OtherGamesControllerTest
    {
        [TestMethod]
        public void OtherGamesTest()
        {
            OtherGamesController _otherGames = new OtherGamesController();

            ViewResult result = _otherGames.OtherGamesView() as ViewResult;

            Assert.AreEqual("Click to Play Other Games", result.ViewBag.OtherGamesTitle);
        }
    }
}

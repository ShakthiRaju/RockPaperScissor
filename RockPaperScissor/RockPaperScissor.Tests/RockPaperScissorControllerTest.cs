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
    public class RockPaperScissorControllerTest
    {
        [TestMethod]
        public void RockPaperScissorViewTest()
        {
            RockPaperScissorController _rockPaperScissor = new RockPaperScissorController();
 
            ViewResult result=_rockPaperScissor.RockPaperScissorView() as ViewResult;

            Assert.AreEqual("Welcome to Rock, Paper & Scissors Game",result.ViewBag.RockPaperScissorTitle);
        }

        [TestMethod]
        public void PlayerGameTest()
        {
            RockPaperScissorController _rockPaperScissor = new RockPaperScissorController();
            string option = "Rock", userName = "Shakthi";
            int PlayerScore = 0, ComputerScore = 0, TieScore = 0;

            var result=_rockPaperScissor.PlayerGame(option, PlayerScore, ComputerScore, TieScore, userName) as JsonResult;

            dynamic data = result.Data;

             Assert.IsNotNull(data.GetType().GetProperty("ComputerResult").GetValue(data, null));
             Assert.IsTrue(data.GetType().GetProperty("PlayerScore").GetValue(data, null) > - 1);
             Assert.IsTrue(data.GetType().GetProperty("ComputerScore").GetValue(data, null) > -1);
             Assert.IsTrue(data.GetType().GetProperty("TieScore").GetValue(data, null) > -1);
             Assert.IsNotNull(data.GetType().GetProperty("MatchResult").GetValue(data, null));

        }

        [TestMethod]
        public void ComputerGame()
        {
            RockPaperScissorController _rockPaperScissor = new RockPaperScissorController();
            int Computer1Score = 0, Computer2Score = 0, TieScore = 0;

            var result=_rockPaperScissor.ComputerGame(Computer1Score, Computer2Score, TieScore) as JsonResult;

            dynamic data = result.Data;

            Assert.IsNotNull(data.GetType().GetProperty("Computer1Result").GetValue(data, null));
            Assert.IsNotNull(data.GetType().GetProperty("Computer2Result").GetValue(data, null));
            Assert.IsTrue(data.GetType().GetProperty("Computer1Score").GetValue(data, null) > -1);
            Assert.IsTrue(data.GetType().GetProperty("Computer2Score").GetValue(data, null) > -1);
            Assert.IsTrue(data.GetType().GetProperty("TieScore").GetValue(data, null) > -1);
            Assert.IsNotNull(data.GetType().GetProperty("MatchResult").GetValue(data, null));

        }

        
    }
}

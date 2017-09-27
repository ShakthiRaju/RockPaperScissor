using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using RockPaperScissor.Models;

namespace RockPaperScissor.Controllers
{
    public class RockPaperScissorController : Controller
    {
        #region Rock Paper Scissor View
        public ActionResult RockPaperScissorView() //Load the Rock Paper Scissor View
        {
            ViewBag.RockPaperScissorTitle = "Welcome to Rock, Paper & Scissors Game";
            return View();
        }
        #endregion

        #region Player Vs Computer Logic
        [HttpPost] // Pass the Player option , Player Score, ComputerScore, TieScore and UserName as a parameter
        public ActionResult PlayerGame(string playerOption,int argPlayerScore, int argComputerScore, int argTieScore, string userName)
        {
            //Initialization
            int computerResult = 0,playerScore=0,computerScore=0,tieScore=0;
            string matchResult=String.Empty;
            //Get the Random number to get the Computer Result      
            Random _random = new Random();
            computerResult = _random.Next(0, 3);

            //Function to find the winner
            FindtheWinner(computerResult, RockPaperScissorModel.RockPaperScissorList.IndexOf(playerOption), out computerScore, out playerScore, out tieScore, out matchResult, argComputerScore, argPlayerScore, argTieScore);

            //Set the Match Result based on the Winner
            matchResult = (matchResult.Equals("player1") ? "Computer Wins!" : (matchResult.Equals("player2")?userName + " Wins!" : "Tie Match"));
            
            //return the result in Json to RockPaperScissorView
            return Json(new { 
                ComputerResult = RockPaperScissorModel.RockPaperScissorList[computerResult].ToString(),
                PlayerScore=playerScore,
                ComputerScore=computerScore,
                TieScore=tieScore,
                MatchResult =matchResult });         
        }
        #endregion

        #region Computer Vs Computer Logic
        [HttpPost]
        public ActionResult ComputerGame(int argComputer1Score,int argComputer2Score,int argTieScore)
        {
            // Initialization
            int computer1Result = 0,computer2Result=0, computer1Score = 0, computer2Score = 0, tieScore = 0;
            string matchResult = String.Empty;
            //Get the Random number for Computer1 and Computer2 
            Random _random = new Random();
            computer1Result = _random.Next(0, 3);
            computer2Result = _random.Next(0, 3);

            //Call the FindtheWinner function to find the winners
            FindtheWinner(computer1Result, computer2Result, out computer1Score, out computer2Score, out tieScore, out matchResult, argComputer1Score, argComputer2Score, argTieScore);

            //Set the Match Result based on the Winner
            matchResult = (matchResult.Equals("player1") ? "Computer1 Wins!" : (matchResult.Equals("player2") ? "Computer2 Wins!" : "Tie Match"));

            //return the result in JSon Format
            return Json(new
            {
                Computer1Result = RockPaperScissorModel.RockPaperScissorList[computer1Result].ToString(),
                Computer2Result = RockPaperScissorModel.RockPaperScissorList[computer2Result].ToString(),
                Computer1Score = computer1Score,
                Computer2Score = computer2Score,
                TieScore = tieScore,
                MatchResult = matchResult
            });
        }
        #endregion

        #region Find the Winner Logic
        public static void FindtheWinner(int player1result,int player2result,out int player1score,out int player2score,out int tiescore,out string matchresult,int argPlayer1Score,int argPlayer2Score,int argTieScore)
        {
            //Initialization
            int tempresult = 0;
            player1score = player2score = tiescore = 0;
            matchresult = String.Empty;
            //Check the match is tie or not
            if (player1result != player2result)
            {
                tempresult = RockPaperScissorModel.RockPaperScissorMapping[player1result + player2result];

                if(player1result==tempresult) //Check the Player1 wins the match or not
                {
                    player1score = argPlayer1Score + 1;
                    matchresult = "player1";
                    player2score = argPlayer2Score;
                    tiescore=argTieScore;
                }
                else if(player2result==tempresult) //Check the Player2 wins the match or not
                {
                    player2score =argPlayer2Score + 1;
                    matchresult = "player2";
                    player1score = argPlayer1Score;
                    tiescore = argTieScore;
                }              
            }
            else
            { // Set the score if the Match is Tie
                matchresult = "Tie Match";
                tiescore = argTieScore + 1;
                player1score = argPlayer1Score;
                player2score = argPlayer2Score;               
            }
       }
        #endregion
    }
}

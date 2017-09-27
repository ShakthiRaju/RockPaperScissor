$(document).ready(function () {
    var timer = 0; //Set the Timer value to zero

    //Hide the Player Form and Computer Form on Rock Player Scissor page load
    $("#playerForm").css("display", "none");
    $("#computerForm").css("display", "none");

    //Hide the Computer vs Computer Form and Show the Player Vs Computer Form
    $("#playerButton").click(function () {
        var _userName = $("#userName").val();
        if (_userName == "")
        { alert("Please Enter Your Name"); }
        else
        {
            $("#playerForm").css("display", "block");
            $("#computerForm").css("display", "none");           
        }
    });

    //On clicking Rock/Paper/Scissors button by Player , below function will execute to find the winner
    $("input").click(function () {
        var mode = $(this).val();
        if (mode == "Rock" || mode == "Paper" || mode == "Scissors") {
            var serviceURL = '/RockPaperScissor/PlayerGame';
            $.ajax({ 
                type: "POST",
                url: serviceURL,
                data: { 'playerOption': mode,'argPlayerScore':$("#playerScore").val(),'argComputerScore':$("#computerScore").val(),'argTieScore':$("#tieScore").val(),'userName':$("#userName").val() },
                
                //contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) { 
                    $("#playerScore").val(data.PlayerScore);
                    $("#computerScore").val(data.ComputerScore);
                    $("#tieScore").val(data.TieScore);
                    $("#playerResult").val(mode);
                    $("#computerResult").val(data.ComputerResult);
                    $("#resultLabel").show();
                    $("#resultLabel").text(data.MatchResult);
                },
                error: function (data) {
                    alert('Server Error : Failed to Play the Game' + data);
                }
            });
        }
    });

         // function to start the Computer Vs Computer game
         function callComputerGame() {
            var serviceURL = '/RockPaperScissor/ComputerGame';
            $.ajax({
                type: "POST",
                url: serviceURL,
                data: { 'argComputer1Score': $("#computer1Score").val(), 'argComputer2Score': $("#computer2Score").val(), 'argTieScore': $("#TieCScore").val() },
                dataType: "json",
                success: function (data) {
                    $("#computer1Score").val(data.Computer1Score);
                    $("#computer2Score").val(data.Computer2Score);
                    $("#TieCScore").val(data.TieScore);
                    $("#computer1Result").val(data.Computer1Result);
                    $("#computer2Result").val(data.Computer2Result);
                    $("#comresultLabel").show();
                    $("#comresultLabel").text(data.MatchResult);
                },
                error: function (data) {
                    alert('Server Error : Failed to Play the Game' + data);
                }
            });
        }
    
    //Click event for Start the game in Computer Vs Computer
    $("#startGame").click(function () {    
        timer = setInterval(callComputerGame, 3000);  //Timer has been set to play the Computer Vs Computer for every 3 seconds     
    });

    //Stop the Computer Vs Computer Game
    $("#stopGame").click(function () {
        clearTimeout(timer); //Clear the Timer
    });

    //Hide the Computer vs Computer Form and Show the Player Vs Computer Form
    $("#computerButton").click(function () {
        $("#playerForm").css("display", "none");
        $("#computerForm").css("display", "block");
    });

    //End the Player Vs Computer Game
    $("#playerEndGame").click(function () {
        $("#playerForm")[0].reset();
        $("#resultLabel").hide();

    });

    //End the Computer Vs Computer Game
    $("#computerEndGame").click(function () {
        $("#computerForm")[0].reset();
        clearTimeout(timer);
        $("#comresultLabel").hide();

    });
});
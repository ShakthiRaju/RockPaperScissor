using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissor.Models
{
    public class RockPaperScissorModel
    {
        //Set the value for Rock Paper Scissor List and its Mapping
        public static Dictionary<int, int> RockPaperScissorMapping =new Dictionary<int, int>{{1,1},{2,0},{3,2}};
        public static List<string> RockPaperScissorList = new List<string>{"Rock","Paper","Scissors"};
     }
}
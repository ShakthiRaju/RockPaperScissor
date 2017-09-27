using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockPaperScissor.Controllers
{
    public class OtherGamesController : Controller
    {
        //Other Games Action Controller
       public ActionResult OtherGamesView()
        {
            ViewBag.OtherGamesTitle = "Click to Play Other Games";
            return View();
        }
    }
}

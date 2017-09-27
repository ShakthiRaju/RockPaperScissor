using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockPaperScissor.Controllers
{
    public class HomeController : Controller
    {   
        //Home Action Controller
        public ActionResult Index()
        {
            ViewBag.HomeTitle = "Waste an hour by having Fun";
            return View();
        }
    }
}

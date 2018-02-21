using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Message = "Please enter your information to register:";
            return View();
        }
 
        public ActionResult RegisterUser(string FirstName, string Position, string Email)
        {
            ViewBag.Message = $"Thank you for resgistering, {FirstName}!\nA confirmation has been sent to {Email}.";

            if(Position == "Forward")
            {
                ViewBag.YourPosition = $"Go get 'em, Gretzky!";
            }
            else if(Position == "Defense")
            {
                ViewBag.YourPosition = $"Number four, Bobby Orr!";
            }
            else
            {
                ViewBag.YourPosition = $"Brick wall!";
            }

            return View("NewUser");
        }
    }
}
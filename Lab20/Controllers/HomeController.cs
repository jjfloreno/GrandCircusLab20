using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab20.Models;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ORM
            HockeyShopDBEntities InventoryList = new HockeyShopDBEntities();

            //load data to display
            ViewBag.Inventory = InventoryList.Items.OrderBy(x => x.ItemCat).ThenBy(x => x.ItemName).ToList();
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
 
        public ActionResult RegisterUser(User newUser)
        {
            //1. ORM
            HockeyShopDBEntities newHockeyUser = new HockeyShopDBEntities();

            //2. Add to list and save to DB.
            //need to validate before accepting email address (PK of customer)

            newHockeyUser.Users.Add(newUser);
            newHockeyUser.SaveChanges();

            //Confirmation on new view and a message based on position
            ViewBag.Message = $"Thank you for resgistering, {newUser.FirstName}!\nA confirmation has been sent to {newUser.Email}.";

            if(newUser.Position == "Forward")
            {
                ViewBag.YourPosition = $"Go get 'em, Gretzky!";
            }
            else if(newUser.Position == "Defense")
            {
                ViewBag.YourPosition = $"Number four, Bobby Orr!";
            }
            else
            {
                ViewBag.YourPosition = $"Brick wall!";
            }

            return View("NewUser");
        }

        public ActionResult SearchByItemName (string Item_Name)
        {
            HockeyShopDBEntities ItemResults = new HockeyShopDBEntities();

            ViewBag.Inventory = ItemResults.Items.Where(x => x.ItemName.Contains(Item_Name))
                .OrderBy(x => x.ItemCat).ThenBy(x => x.ItemName).ToList();

            return View("Index");
        }

        public ActionResult SelectItemCategory (string ViewCategory)
        {
            HockeyShopDBEntities CatResults = new HockeyShopDBEntities();

            ViewBag.Inventory = CatResults.Items.Where(x => x.ItemCat == ViewCategory)
                .OrderBy(x => x.ItemCat).ThenBy(x => x.ItemName).ToList();

            return View("Index");
        }
    }
}
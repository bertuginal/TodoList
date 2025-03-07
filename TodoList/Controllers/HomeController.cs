using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.DAL;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            bool isUser = false;

            if (Session["UserId"] != null)
            {
                var userId = (int)Session["UserId"];

                isUser = db.Users.Any(a => a.Id == userId);
                if (isUser)
                {
                    ViewBag.isUser = isUser;
                }
            }

            if (Session["UserId"] != null)
            {
                var userId = (int)Session["UserId"];
                var user = db.Users.FirstOrDefault(a => a.Id == userId);
                if (user != null)
                {
                    ViewBag.UserName = user.Username;
                    ViewBag.UserEmail = user.Id;

                }
            }
            return View();
            }
        }
    }
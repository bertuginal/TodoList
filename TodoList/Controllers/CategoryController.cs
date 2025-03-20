using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.DAL;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category/Index
        public ActionResult Index()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            bool isUser = false;
            var userId = (int)Session["UserId"];

            if (Session["UserId"] != null)
            {
                isUser = db.Users.Any(a => a.Id == userId);
                if (isUser)
                {
                    ViewBag.isUser = isUser;
                }
            }

            if (Session["UserId"] != null)
            {
                var user = db.Users.FirstOrDefault(a => a.Id == userId);
                if (user != null)
                {
                    ViewBag.UserName = user.Username;
                    ViewBag.UserEmail = user.Email;

                }
            }

            var categories = db.Categories
                .Where(c => c.Notes.Any(n => n.UserId == userId))
                .ToList();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }

}
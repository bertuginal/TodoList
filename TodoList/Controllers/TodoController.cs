using System.Linq;
using System.Web.Mvc;
using System.Data;
using TodoList.Models;
using TodoList.DAL;
using System;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Todo
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
                    ViewBag.UserEmail = user.Id;

                }
            }

            var todos = db.TodoItems.Where(t => t.UserId == userId).ToList();
            return View(todos);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var todo = db.TodoItems.Find(id);
            return View(todo);
        }

        // GET: Todo/Create
        public ActionResult Create()
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
                    ViewBag.UserEmail = user.Id;

                }
            }

            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(TodoItem todo)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to create a todo!");
                return View(todo);
            }

            if (ModelState.IsValid)
            {
                todo.UserId = (int)Session["UserId"];
                todo.IsCompleted = false;
                todo.CreatedDate = DateTime.Now;

                db.TodoItems.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
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
                    ViewBag.UserEmail = user.Id;

                }
            }

            var todo = db.TodoItems.Find(id);
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(TodoItem todo)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to edit a todo!");
                return View(todo);
            }

            if (ModelState.IsValid)
            {
                var existingTodo = db.TodoItems.Find(todo.Id);

                if(existingTodo!= null) {
                    existingTodo.Title = todo.Title;
                    existingTodo.Description = todo.Description;
                    existingTodo.IsCompleted = todo.IsCompleted;
                    existingTodo.CreatedDate = existingTodo.CreatedDate;
                    existingTodo.CompletionTime = todo.CompletionTime;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(todo);
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
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
                    ViewBag.UserEmail = user.Id;

                }
            }

            var todo = db.TodoItems.Find(id);
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var todo = db.TodoItems.Find(id);
            db.TodoItems.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

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

        // ****************************** Note ******************************
        // GET: Todo
        public ActionResult NoteIndex()
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

            var notes = db.Notes.Where(t => t.UserId == userId).ToList();
            return View(notes);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var note = db.Notes.Find(id);
            return View(note);
        }

        // GET: Todo/NoteCreate
        public ActionResult NoteCreate()
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

        // POST: Todo/NoteCreate
        [HttpPost]
        public ActionResult NoteCreate(Note note)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to create a todo!");
                return View(note);
            }

            if (ModelState.IsValid)
            {
                note.UserId = (int)Session["UserId"];
                note.CreatedDate = DateTime.Now;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("NoteIndex");
            }
            return View(note);
        }

        // GET: Todo/NoteEdit/5
        public ActionResult NoteEdit(int id)
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

            var note = db.Notes.Find(id);
            return View(note);
        }

        // POST: Todo/NoteEdit/5
        [HttpPost]
        public ActionResult NoteEdit(Note note)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to edit a todo!");
                return View(note);
            }

            if (ModelState.IsValid)
            {
                var existingTodo = db.Notes.Find(note.Id);

                if(existingTodo!= null) {
                    existingTodo.Title = note.Title;
                    existingTodo.Description = note.Description;
                    existingTodo.CreatedDate = existingTodo.CreatedDate;
                    existingTodo.Reminder = note.Reminder;

                    db.SaveChanges();
                    return RedirectToAction("NoteIndex");
                }
            }
            return View(note);
        }

        // GET: Todo/NoteDelete/5
        public ActionResult NoteDelete(int id)
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

            var note = db.Notes.Find(id);
            return View(note);
        }

        // POST: Todo/NoteDelete/5
        [HttpPost, ActionName("NoteDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("NoteIndex");
        }

        // ****************************** Task ******************************

    }
}

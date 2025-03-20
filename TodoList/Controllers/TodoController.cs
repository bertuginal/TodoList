using System.Linq;
using System.Web.Mvc;
using System.Data;
using TodoList.Models;
using TodoList.DAL;
using System;
using System.Data.Entity;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // ****************************** Note ******************************

        // GET: Todo/NoteIndex
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
                    ViewBag.UserEmail = user.Email;

                }
            }

            var notes = db.Notes
                .Where(t => t.UserId == userId)
                .Include(n => n.Category)
                .ToList();

            var categories = notes
                .Where(n => n.Category != null)
                .Select(n => n.Category.Name)
                .Distinct()
                .ToList();

            ViewBag.Categories = categories;

            return View(notes);
        }

        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var note = db.Notes.Include(n => n.Category).FirstOrDefault(n => n.Id == id);
            return View(note);
        }

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
                    ViewBag.UserEmail = user.Email;

                }
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult NoteCreate(Note note)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to create a note!");
                return View(note);
            }

            if (ModelState.IsValid)
            {
                note.UserId = (int)Session["UserId"];
                note.CreatedDate = DateTime.Now;
                note.EditedDate = DateTime.Now;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("NoteIndex");
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(note);
        }

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
                    ViewBag.UserEmail = user.Email;

                }
            }

            var note = db.Notes.Find(id);
            if (note == null) return HttpNotFound();

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name", note.CategoryId);
            return View(note);
        }

        [HttpPost]
        public ActionResult NoteEdit(Note note)
        {
            if (Session["UserId"] == null)
            {
                ModelState.AddModelError("", "You must be logged in to edit a note!");
                return View(note);
            }

            if (ModelState.IsValid)
            {
                var existingNote = db.Notes.Find(note.Id);
                if (existingNote != null)
                {
                    existingNote.Title = note.Title;
                    existingNote.Description = note.Description;
                    existingNote.EditedDate = DateTime.Now;
                    existingNote.Reminder = note.Reminder;
                    existingNote.CategoryId = note.CategoryId;

                    db.SaveChanges();
                    return RedirectToAction("NoteIndex");
                }
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name", note.CategoryId);
            return View(note);
        }

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
                    ViewBag.UserEmail = user.Email;

                }
            }

            var note = db.Notes.Include(n => n.Category).FirstOrDefault(n => n.Id == id);
            return View(note);
        }

        [HttpPost, ActionName("NoteDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var note = db.Notes.Find(id);
            if (note != null)
            {
                db.Notes.Remove(note);
                db.SaveChanges();
            }
            return RedirectToAction("NoteIndex");
        }

        // ****************************** Task ******************************

        // GET: Todo/TaskIndex
        public ActionResult TaskIndex()
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

            var tasks = db.Tasks.Where(t => t.UserId == userId).ToList();
            return View(tasks);
        }

    }
}

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
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Todo
        public ActionResult Index()
        {
            var userId = (int)Session["UserId"];
            var todos = _context.TodoItems.Where(t => t.UserId == userId).ToList();
            return View(todos);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            var todo = _context.TodoItems.Find(id);
            return View(todo);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
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
                todo.CreatedAt = System.DateTime.Now;
                todo.IsCompleted = false;
                _context.TodoItems.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            var todo = _context.TodoItems.Find(id);
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
                _context.Entry(todo).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            var todo = _context.TodoItems.Find(id);
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var todo = _context.TodoItems.Find(id);
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

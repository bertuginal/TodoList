using System.Linq;
using System.Web.Mvc;
using System.Data;
using TodoList.Models;
using TodoList.DAL;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var username = new User
                {
                    Username = user.Username,
                    Password = user.Password // Şifreyi burada hashleyip saklayabilirsiniz (güvenlik açısından tavsiye edilir)
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Session["UserId"] = user.Id;
                return RedirectToAction("Index", "Todo");
            }
            ModelState.AddModelError("", "Invalid username or password!");
            return View();
        }


        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            bool isUser = false;

            if (Session["UserId"] != null)
            {
                var userId = (int)Session["UserId"];
                isUser = _context.Users.Any(a => a.Id == userId);
            }

            ViewBag.IsUser = isUser;

            if (Session["UserId"] != null)
            {
                var sessionId = (int)Session["UserId"];
                var userId = _context.Users.FirstOrDefault(a => a.Id == sessionId);
                if (userId != null)
                {
                    ViewBag.UserName = userId.Username;
                    ViewBag.UserEmail = userId.Id;

                }
            }
            return View(user);
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}

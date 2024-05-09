using Microsoft.AspNetCore.Mvc;
using TaskIT.Models;
using TaskIT.Services;
using Microsoft.AspNetCore.Http;

namespace TaskIT.Controllers
{
    public class HomeController : Controller
    {
        BookRepository BookServices = new BookRepository();
        ProgContext DB = new ProgContext();
        User user1 = new User();

        public IActionResult Index()
        {
            List<Book> books = BookServices.getAll();
            return View(books);
        }

        public IActionResult Index1()
        {
            List<Book> books = BookServices.getAll();
            return View(books);
        }

        public IActionResult Signup()
        {
            return View(user1);
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if(DB.Users.Any(x => x.Name == user.Name))
            {
                ViewBag.Notification = "This account has already exists";
                return View("Signup" , user);
            }
            else
            {
                DB.Users.Add(user);
                DB.SaveChanges();

                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("Name", user.Name);

                return RedirectToAction("Index1");   

            }
           
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        
        public IActionResult Login()
        {
            return View(user1);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var check = DB.Users.Where(x => x.Name.Equals(user.Name) && x.Password.Equals(user.Password)).FirstOrDefault();
            if(check != null)
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("Name", user.Name);
                return RedirectToAction("Index1" , "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View(user1);
            }
            
        }
    }
}

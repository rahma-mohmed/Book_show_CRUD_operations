using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using TaskIT.Models;
using TaskIT.Services;

namespace TaskIT.Controllers
{
    public class UserController : Controller
    {
        UserRepository userServices = new UserRepository();

        public IActionResult Add()
        {
            User user = new User();
            return View(user);
        }

        public IActionResult SaveAdd(User user)
        {
            if (ModelState.IsValid == true)
            {
                userServices.Create(user);
                return RedirectToAction("Index" , "Home");
            }

            return View("Add", user);
        }
    }

}

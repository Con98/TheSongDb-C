using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheSongDb.Models;
using TheSongDb.ViewModels;

namespace TheSongDb.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new UserFormViewModel
            {
                User = new User()
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user
                };

                return View("UserForm", viewModel);
            }

            if (user.userId == 0)
                _context.Users.Add(user);
            else
            {
                var userInDb = _context.Users.Single(u => u.Id == user.userId);
                userInDb.firstName = user.firstName;
                userInDb.surname = user.surname;
                userInDb.userName = user.userName;
                userInDb.email = user.email;
                userInDb.password = user.password;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ViewResult Index()
        {
            return View(User);
        }

        public ActionResult Details(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel
            {
                User = user
            };

            return View("UserForm", viewModel);
        }
    }
}
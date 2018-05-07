using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheSongDb.Models;
using TheSongDb.ViewModels;
using System.Data.Entity;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TheSongDb.Controllers
{
    public class FriendController : Controller
    {
        private ApplicationDbContext _context;

        public FriendController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Friend
        public ActionResult Index()
        {
            var friends = _context.Friends.Include(f => f.friend2).ToList();
            return View(friends);
        }

        public ActionResult Details (int? id)
        {
            var friend = _context.Friends.SingleOrDefault(a => a.friendId == id);
            if (friend == null)
            {
                return HttpNotFound();
            }

            return View(friend);
        }

        private IJEnumerable<User> GetUsers()
        {
            return new List<User> { };
        }

        public ActionResult New()
        {
            var UserFriend = _context.Users.ToList();
            var friend = new Friend();
            var viewModel = new FriendRequestViewModel
            {
                Friend = friend,
                
            };

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = _context.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }

            var viewModel = new FriendRequestViewModel
            {

                Friend = friend

                Friend = friend,
                User = _context.Users.ToList()

            };
            return View("Delete", viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = _context.Friends.Find(id);
            _context.Friends.Remove(friend);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
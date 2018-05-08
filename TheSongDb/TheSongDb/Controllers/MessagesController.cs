using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheSongDb.Models;
using TheSongDb.ViewModels;
using System.Data.Entity;
using System.Net;

namespace TheSongDb.Controllers
{
    public class MessagesController : Controller
    {
        public ApplicationDbContext _context;
        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose();
        }

        public ActionResult Index()
        {
            var messages = GetMessages();
            return View(messages);
        }

        public IEnumerable<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }
        public ActionResult New()
        {
            var message = new Message();
            var ViewModel = new MessageFormViewModel
            {
                Message = message
            };
            return View(ViewModel);
        }


    }
}
        
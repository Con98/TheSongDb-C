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
            base.Dispose(disposing);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MessageFormViewModel viewModel)
        {
            //viewModel.Message = _context.Messages.FirstOrDefault(g => g.Id == viewModel.Message.Id); //GIVES ERROR
            /*viewModel.Message = _context.Messages.First(); //WORKS BUT DOESNT SUBMIT
            if (!ModelState.IsValid)
            {
                viewModel = new MessageFormViewModel
                {
                    Message = viewModel.Message
                };
                return View("New", viewModel);
            }
            if (viewModel.Message.Id == 0)
                _context.Messages.Add(viewModel.Message);
            else
            {
                var messageInDb = _context.Messages.Single(messageT => messageT.Id == viewModel.Message.Id);
                messageInDb.content = viewModel.Message.content;
            }*/
            _context.Messages.Add(viewModel.Message);
            _context.SaveChanges();

            return RedirectToAction("Index", "Messages");

        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = _context.Messages.Find(id);
            if(message == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MessageFormViewModel
            {
                Message = message
            };
            return View("Delete", viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

        
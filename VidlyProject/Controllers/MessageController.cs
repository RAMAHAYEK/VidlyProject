using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;

namespace VidlyProject.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext _context;

        public MessageController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Message message)
        {
            if(message.Id == 0)
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
            }
            return Json( "saved successfully .");
          
        }
    }
}
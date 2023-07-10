using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        UserManager userManager = new UserManager(new EfUserRepository());

        Context context = new Context();
        [HttpGet]
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendBoxWithByWriter(writerID);
            return View(values);
        }

        [HttpGet("/Message/MessageDetails/{messageID}")]
        public IActionResult MessageDetails(int messageID)
        {
            var messageValues = message2Manager.GetEntityByID(messageID);
            return View(messageValues);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            GetUsersForMessage();
            ViewBag.GetUsersForMessage = GetUsersForMessage();

            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            //Verileri(kullanıcıları) viewbag ile taşıyoruz.
            ViewBag.GetUsersForMessage = GetUsersForMessage();
            //giriş yapan kullanıcının adını alıyoruz
            var userName = User.Identity.Name;
            //adına göre mailini buluyoruz
            var userMail = context.Users.
                Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //yazarlar tablosundaki maili ile aspnetusers tablosundaki mail eşleşince writerID yi çekiyor
            var writerID = context.Writers.
                Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerID;
            //message.ReceiverID = 2;
            message.MessageStatus = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.AddEntity(message);
            return RedirectToAction("InBox");
        }

        public List<SelectListItem> GetUsersForMessage()
        {
            var users = (from x in userManager.GetListEntity()
                         select new SelectListItem
                         {
                             Text = x.Email,
                             Value = x.Id.ToString()

                         }).ToList();
            return users;
        }

    }
}

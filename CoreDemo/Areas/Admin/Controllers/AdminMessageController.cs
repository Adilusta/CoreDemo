using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        UserManager<AppUser> _userManager;
        UserManager _myUserManager = new UserManager(new EfUserRepository());
        Context context = new Context();

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            
            return View(values);

        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendBoxWithByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            ViewBag.GetUsersForMessage = GetUsersForMessage();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ComposeMessage(Message2 message)
        {
            ViewBag.GetUsersForMessage = GetUsersForMessage();


            //var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var userId = user.Id;
            message.SenderID = userId;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            message2Manager.AddEntity(message);
            return RedirectToAction("SendBox");
        }

        public List<SelectListItem> GetUsersForMessage()
        {
            var users = (from x in _myUserManager.GetListEntity()
                         select new SelectListItem
                         {
                             Text = x.Email,
                             Value = x.Id.ToString()

                         }).ToList();
            return users;
        }

        public IActionResult ShowMessageCount()
        {
            var userName = User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName);
            var userID = user.Id;
            int result = context.Message2s.Where(x => x.ReceiverID == userID).Count();
            ViewBag.MessageCount=result;
            return PartialView("AdminMailboxSidebarPartial", ViewBag.MessageCount);
        }


    }
}

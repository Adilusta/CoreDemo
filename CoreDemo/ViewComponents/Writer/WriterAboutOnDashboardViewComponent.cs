

using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
   
    public class WriterAboutOnDashboardViewComponent  : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context c = new Context();


        public  IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var result = writerManager.GetEntityByID(writerID);
            return View(result);
            //return View();
        }

        //public IViewComponentResult Invoke()
        //{
           
        //    var userMail = User.Identity.Name;
        //    var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
        //    var result = writerManager.GetEntityByID(writerID);
        //    return View(result);
        //}
    }
}

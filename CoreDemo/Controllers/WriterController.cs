using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class WriterController : Controller
    {
        Context context = new Context();
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
          
            var writerName = context.Writers.
                Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
       
        public IActionResult WriterProfile()
        {
            return View();
        }
       
        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public  IActionResult WriterEditProfile()
        {
            UserManager userManager = new UserManager(new EfUserRepository());
            var userName= User.Identity.Name;
            var userMail = context.Users.Where(x=>x.UserName==userName).Select(y=>y.Email).FirstOrDefault();
            //var writerID= context.Writers.
            //    Where(x=>x.WriterMail==userMail).Select(y => y.WriterID).FirstOrDefault();
            //var writerValues = writerManager.GetEntityByID(writerID);
            //return View(writerValues);
        
            var id = context.Users.Where(x=>x.Email==userMail).Select(y=>y.Id).FirstOrDefault();
            var values= userManager.GetEntityByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();

            var writerValues = writerManager.GetEntityByID(1);
            ValidationResult validationResult = writerValidator.Validate(writer);

            if (writer.WriterPassword != writer.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Şifreler eşleşmiyor");
            }

            if (validationResult.IsValid && ModelState.IsValid)
            {
                writerManager.UpdateEntity(writer);
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
         public IActionResult WriterAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.WriterImage!=null)
            {
                // dosyanın uzantısını döndürür(jpeg,png gibi)
                var extension= Path.GetExtension(p.WriterImage.FileName);
                /*Global Unique Identifier kullanarak benzersiz bir isim oluşturuyoruz dosyaya ve sonuna da
                 dosya uzantısnı ekliyoruz. */
                var newImageName = Guid .NewGuid()+ extension;
                /*Directory.GetCurrentDirectory() metodu, uygulamanın çalıştığı dizinin tam yolunu alır.Sonrasında ise wwwroot dizininin
                 * WriterImageFiles  alt klasörünü yazarız sonra ise demin oluşturduğumuz benzersiz dosya adını yazarız.  Tüm bunları
                 Path.Combine ile birleştirirz.*/
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);

                /*stream nesnesi oluşturup Create modunu seçerek, dosyanın oluşturulacağını ve mevcut bir dosyanın
                üzerine yazılacağını belirtir*/
                var stream = new FileStream(location,FileMode.Create);
               // resim dosyamızı stream nesnesine kopyalıyoruz.Bu sayede resim dosyası location ı verdiğimiz yerde oluşturulur.
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = p.WriterMail;
            writer.WriterName = p.WriterName;
            writer.WriterPassword = p.WriterPassword;
            writer.ConfirmPassword = p.ConfirmPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = p.WriterAbout;
            writerManager.AddEntity(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

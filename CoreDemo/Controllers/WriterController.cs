using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
      
        public IActionResult Index()
        {
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
        public IActionResult WriterEditProfile()
        {
            var writerValues = writerManager.GetEntityByID(1);
            return View(writerValues);
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
    }
}

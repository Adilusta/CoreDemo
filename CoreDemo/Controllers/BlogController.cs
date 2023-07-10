using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
 
    public class BlogController : Controller
    {
        IBlogService blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {

            var result = blogManager.GetBlogsWithCategory();
            return View(result);
        }

        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            ViewBag.BlogID = id;
            var result = blogManager.GetEntityByID(id);
            return View(result);
        }
        public IActionResult BlogListByWriter()
        {
            //var userMail = User.Identity.Name;
            var userName=User.Identity.Name;


            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.WriterID = writerID;
            //var writerID = context.Writers.
            //    Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            //ViewBag.WriterID = writerID;
            var result = blogManager.GetListWithCategoryByWriter(writerID);
            return View(result);
        }
        
        [HttpGet]
        public IActionResult BlogAdd()
        {
            var values = ListCategoriesWithDropdownList();
            ViewBag.categoriesWithDropdownList= values;

            return View();

        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {

            var userName = User.Identity.Name;


            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            //DropdownList boş kalmasın diye HttpPost'ta da dropdownlist verilerini getiriyoruz.
            var values = ListCategoriesWithDropdownList();
            ViewBag.categoriesWithDropdownList = values;


            BlogValidator validator = new BlogValidator();
            ValidationResult results = validator.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                blogManager.AddEntity(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        
        [HttpGet("/Blog/BlogDelete/{a}")]
        public IActionResult BlogDelete(int a)
        {
            var value= blogManager.GetEntityByID(a);
            blogManager.DeleteEntity(value);
            return RedirectToAction("BlogListByWriter");

        }
        public List<SelectListItem> ListCategoriesWithDropdownList()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetListEntity()
                                                   select new SelectListItem
                                                   {
                                                       
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),

                                                   }).ToList();
            return (categoryvalues);
        }

        [HttpGet("/Blog/EditBlog/{blogId}")]
        public IActionResult EditBlog(int blogId)
        {


            //Kategorileri getirir
            var values = ListCategoriesWithDropdownList();
            ViewBag.categoriesWithDropdownList = values;

            //Gelen Id ye ait olan bloğu bulur.
            var blogValue= blogManager.GetEntityByID(blogId);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {


            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            //DropdownList boş kalmasın diye HttpPost'ta da dropdownlist verilerini getiriyoruz.
            var values = ListCategoriesWithDropdownList();
            ViewBag.categoriesWithDropdownList = values;

            blog.WriterID = writerID;
            blog.BlogStatus = true;

            blogManager.UpdateEntity(blog);
            return RedirectToAction("BlogListByWriter","Blog");

        }






    }
}

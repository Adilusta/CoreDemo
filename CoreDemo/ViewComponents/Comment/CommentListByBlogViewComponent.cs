using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlogViewComponent : ViewComponent
    {
        ICommentService _commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            //ViewData["BlogId"]=id;
            ViewBag.BlogId = id;
            var commentValues = _commentManager.GetListCommentByBlogID(id);
            return View(commentValues);
        }
    }
}

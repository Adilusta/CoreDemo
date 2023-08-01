using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Math;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminCommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = _commentManager.GetListCommentWithBlog();
            return View(values);
        }
        [HttpGet("/Admin/AdminComment/EditComment/{commentID}")]
        public IActionResult EditComment(int commentID)
        {
            var value = _commentManager.GetCommentWithBlogByCommentID(commentID);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            _commentManager.UpdateEntity(comment);
            return RedirectToAction("Index");
        }

        [HttpGet("/Admin/AdminComment/DeleteComment/{commentID}")]
        public IActionResult DeleteComment(int commentID)
        {
            var comment = _commentManager.GetEntityByID(commentID);
            _commentManager.DeleteEntity(comment);
            return RedirectToAction("Index");
        }
    }
}



using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		ICommentService _commentManager = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return View();
		}
		[HttpPost("/Comment/PartialAddComment")]
		public IActionResult PartialAddComment(Comment comment,int id=6)
		{
			comment.CommentDate = DateTime.Now;
			//comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogId = id;
			_commentManager.AddEntity(comment);
			return RedirectToAction("Index", "Blog");
		}
	}
}
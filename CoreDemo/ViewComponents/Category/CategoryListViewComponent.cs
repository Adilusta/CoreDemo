using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryListViewComponent : ViewComponent
	{
		ICategoryService categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
		public IViewComponentResult Invoke()
        {
            var categoriesWithBlogCounts = context.Categories
           .Select(c => new CategoryCountByBlogsViewModel
           {
               CategoryId = c.CategoryID,
               CategoryName = c.CategoryName,
               BlogCount = c.Blogs.Count()
           }).ToList();
            //var categories = categoryManager.GetListEntity();
			return View(categoriesWithBlogCounts);
		}
	}
}

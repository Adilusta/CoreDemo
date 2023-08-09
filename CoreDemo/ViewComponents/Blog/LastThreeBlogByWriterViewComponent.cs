using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
	public class LastThreeBlogByWriterViewComponent : ViewComponent
	{
		IBlogService _blogManager = new BlogManager(new EfBlogRepository());
		Context context = new Context();
		UserManager<AppUser> _userManager;
        

        public LastThreeBlogByWriterViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IViewComponentResult> InvokeAsync()
		{
			try
			{
			    var userName = User.Identity.Name;
			    var user = await _userManager.FindByNameAsync(userName);
			    var result = _blogManager.GetBlogsByWriter(user.Id);
                result.Reverse();
                return View(result);
            }
            catch
            {
                ViewBag.message = "Daha önce hiç blog yazısı yazmamışsınız.Haydi bir blog yazısı yazın.";
                return View();

            }
        }
    }
	
}

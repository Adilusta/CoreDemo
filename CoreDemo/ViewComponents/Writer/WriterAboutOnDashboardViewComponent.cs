

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
   
    public class WriterAboutOnDashboardViewComponent  : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var result = writerManager.GetEntityByID(1);
             return View(result);
        }
    }
}

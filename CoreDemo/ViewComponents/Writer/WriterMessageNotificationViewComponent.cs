using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotificationViewComponent : ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
         
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}

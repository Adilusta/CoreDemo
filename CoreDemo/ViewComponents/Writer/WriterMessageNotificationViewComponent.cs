using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotificationViewComponent : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string mail;
            mail = "adilusta4@gmail.com";
            var values = messageManager.GetInboxListByWriter(mail);
            return View(values);
        }
    }
}

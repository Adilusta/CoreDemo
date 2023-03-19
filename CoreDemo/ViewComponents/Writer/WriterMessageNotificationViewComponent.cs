using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotificationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager= new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 2;

            var values = message2Manager.GetInboxListByWriter(id);
        

            return View(values);
        }
        [HttpGet("/Message/MessageDetails/{messageID}")]
        public IActionResult MessageDetails(int messageID)
        {
            var messageValues= message2Manager.GetEntityByID(messageID);
            return View(messageValues);  
        }

    }
}

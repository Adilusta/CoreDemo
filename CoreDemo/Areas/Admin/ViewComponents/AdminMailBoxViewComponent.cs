using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace CoreDemo.Areas.Admin.ViewComponents
{
    public class AdminMailBoxViewComponent : ViewComponent
    {
        Context context = new Context();
        UserManager<AppUser> _userManager;
        public AdminMailBoxViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task <IViewComponentResult> InvokeAsync()
        {
            //giriş yapan kullancıyı buluyoruz.
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            int userID = user.Id;
            //gelen mesaj sayısını buluyoruz
            int incomingMessagesCount = context.Message2s.Where(x => x.ReceiverID == userID).Count();
            //giden mesaj sayısını buluyoruz
            int outGoingMessagesCount = context.Message2s.Where(x => x.SenderID == userID).Count();
            //view modelden nesne türetip içini  dolduruyoruz
            var viewModel = new AdminMailBoxViewModel()
            {
                IncomingMessageCount = incomingMessagesCount,
                OutgoingMessageCount = outGoingMessagesCount
            };
            return View(viewModel);
        }
    }
}

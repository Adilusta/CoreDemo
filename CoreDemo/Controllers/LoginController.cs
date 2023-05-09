using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                /*üçüncü parametre beni hatırla gibi bir şey,dördüncü parametre ise başarısız girişler 
                  sonucunda lockout etkinleştirilsin mi? Burada true diyoruz,5 kere başarısız giriş yaparsa
                  sistemden engellenecek belli bir süre boyunca. */
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }



        //CLAIMS IDENTITY İLE GİRİŞ YAPMA
        /*[HttpPost]
        public async Task <IActionResult> Index(Writer writer)
        {
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail
            && x.WriterPassword == writer.WriterPassword);
            if (dataValue != null)
            {
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,writer.WriterMail)
				};
				var userIdentity = new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }	
            else
            {
                return View();
            }*/


        //SESSION İLE GİRİŞ YAPMA

        //Context context = new Context();
        //var dataValue = context.Writers.FirstOrDefault(x=>x.WriterMail==writer.WriterMail
        //&& x.WriterPassword==writer.WriterPassword);
        //if (dataValue!=null)
        //{
        //	HttpContext.Session.SetString("username",writer.WriterMail);
        //	return RedirectToAction("Index","Writer");
        //}
        //else
        //{
        //return View();
        // }

    }
}



using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1ViewComponent : ViewComponent
    {
     
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.vbBlogCount = context.Blogs.Count().ToString();
            ViewBag.vbContactMessageCount = context.Contacts.Count().ToString();
            ViewBag.vbCommentCount= context.Comments.Count().ToString();

            //api keyimiz
            string api = "59c6f3798350a371f0f3894a73256666";
            // api url'imiz
            string connection =
       "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;
            //Bir xml dökümanı açıp url imizi ona yüklüyoruz.
            XDocument document = XDocument.Load(connection);
            //temperature elementinin value attribute unun değerini çekiyoruz.
            ViewBag.temperature =document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}

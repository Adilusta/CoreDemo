using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class WriterController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }

        //[Route("Admin/Writer/WriterList/{id?}")]
        public IActionResult WriterList()
        {
            //writers ı json türüne çevirir
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerID)
        {
            var writer = writers.FirstOrDefault(x => x.ID == writerID);
            var jsonWriters= JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriters=JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

       
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(writer);
            return Ok();
            //return Json(writer);
        }

        [HttpPost]
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.ID == w.ID);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID=1,
                Name="Ayşe"

            },
            new WriterClass
            {
                ID=2,
                Name="Ahmet"

            },
              new WriterClass
            {
                ID=3,
                Name="Buse"

            }
        };
    }
}

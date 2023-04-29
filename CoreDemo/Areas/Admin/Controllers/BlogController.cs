using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook= new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //sheet adı
                worksheet.Cell(1, 1).Value = "Blog ID"; //1. satır 1.sütun
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır ikinci sütun

                int BlogRowCount = 2; // 2.satırdan başlatıyoruz çünkü 1.satırda başlıklar var zaten
                foreach(var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value=item.ID;  //2. satır 1.sütun 
                    worksheet.Cell(BlogRowCount, 2).Value=item.BlogName; //2.satır 2.sütun 
                    BlogRowCount++;//satır sayısını her defasında arttıralım
                }

                using (var stream= new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-" +
                        "officedocument.spreadsheetml.sheet","Calisma1.xlsx" );
                }
            }
                //return View();
        }
       public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
            { 
                new BlogModel{ID=1,BlogName="C# Programlamaya giriş"},
                new BlogModel{ID=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2020 Olimpiyatları"},
            };
            return blogList;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //sheet adı
                worksheet.Cell(1, 1).Value = "Blog ID"; //1. satır 1.sütun
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır ikinci sütun

                int BlogRowCount = 2; // 2.satırdan başlatıyoruz çünkü 1.satırda başlıklar var zaten
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;  //2. satır 1.sütun 
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName; //2.satır 2.sütun 
                    BlogRowCount++;//satır sayısını her defasında arttıralım
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-" +
                        "officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> blogModel = new List<BlogModel2>();
            using (var context = new Context())
            {
                blogModel = context.Blogs.Select(x => new BlogModel2
                {
                    ID=x.BlogId,
                    BlogName= x.BlogTitle
                }).ToList();
            }
            return blogModel;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}

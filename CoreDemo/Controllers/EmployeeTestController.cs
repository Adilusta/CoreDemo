using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> Index()
        {

            //httpClient ile get isteği yapıyoruz ve HttResponseMessage türünde bir şey dönüyor
            var responseMessage = await httpClient.GetAsync("https://localhost:44311/api/Default");
            //Dönen verileri string olarak okuyoruz
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            //sonrasında verileri Class1 adındaki sınıfın nesnelerine dönüştürüyoruz.
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {

            //p parametresini json a çeviriyoruz
            var jsonEmployee = JsonConvert.SerializeObject(p);
            /*post isteğine göndermek üzere bir content oluşturuyoruz.İlk parametre content,content olarak jsona
             çevirdiğimiz şeyi veriyoruz,ikincisi encoding türü ASCII falan var biz UTF8 seçiyoruz.Son olarak da 
            medya türü istiyor o da json türünde olacak diyoruz.*/
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            // URL ve content i kullanrak post isteği gönderiyoruz.
            var responseMessage = await httpClient.PostAsync("https://localhost:44311/api/Default", content);
            //eğer başarılıysa index e geri atsın bizi
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {

            var responseMessage = await httpClient.GetAsync("https://localhost:44311/api/Default/" + id);
            //var responseMessage = await httpClient.GetAsync($"https://localhost:44311/api/Default/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44311/api/Default/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44311/api/Default/" + id);
            //var responseMessage = await httpClient.DeleteAsync($"https://localhost:44311/api/Default/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
         
        }
    }


    public class Class1
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}

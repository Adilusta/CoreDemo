using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult EmployeeList()
        {

            var values = context.Employees.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var result = context.Employees.FirstOrDefault(x => x.ID == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
   
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = context.Employees.FirstOrDefault(x => x.ID == id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(result);
                context.SaveChanges();
                return Ok();
            }
          
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var result = context.Employees.FirstOrDefault(x => x.ID == employee.ID);
            //var deneme = context.Find<Employee>(employee.ID);  bu da oluyor.

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Name = employee.Name;
                context.Update(result);
                context.SaveChanges();
                return Ok(result);
            }

        }
    }
}

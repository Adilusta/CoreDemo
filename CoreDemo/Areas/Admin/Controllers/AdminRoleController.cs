using CoreDemo.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager; //rol içerisine alacağımız entity
        private readonly UserManager<AppUser> _userManager;

		public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult Index()
        {

            //rolleri listeleme
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet("/Admin/AdminRole/AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = roleViewModel.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(roleViewModel);
        }

        [HttpGet("/Admin/AdminRole/UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values= _roleManager.Roles.Where(x=>x.Id==model.Id).FirstOrDefault();
            values.Name = model.Name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }

        [HttpGet("/Admin/AdminRole/DeleteRole/{Id}")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            var values = _roleManager.Roles.Where(x=>x.Id==Id).FirstOrDefault();
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();

            return View(values);
        }
      
        [HttpGet]
        public async Task <IActionResult> AssignRole(int id)
        {
            //id ye göre kullanıcıyı buluyoruz.
            var user = _userManager.Users.FirstOrDefault(x=> x.Id==id);
            //rolleri listeliyoruz
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id;
            //Parametre olarak verdiğimiz kullanıcının rollerini getiriyor.
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel
                {
                    //id ve name
                    RoleID = item.Id,
                    Name = item.Name,
                    //Foreach ile rolleri dönüp hangi rolün, kullanıcının rolleri oldugunu tespit ediyoruz.
                    Exist = userRoles.Contains(item.Name)
                };
                model.Add(m);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
            }
            return View();
        }
    }
}
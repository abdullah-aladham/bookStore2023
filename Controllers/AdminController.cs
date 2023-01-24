using BookStore2.Data;
using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var admins = _context.BookStoreAdmins.ToList();
            List<AdminViewModel> adminList = new List<AdminViewModel>();

            if (admins != null)
            {
                foreach (var admin in admins)
                {
                    var AdminViewModel = new AdminViewModel()
                    {
                        Id = admin.Id,
                        Name = admin.Name
                    };
                    adminList.Add(AdminViewModel);
                }
                return View(adminList);
            }
            return View(adminList);
        }
        public IActionResult AddAdmin(AdminViewModel adminData)
        { 
        
            if(ModelState.IsValid)
            {
                var admin = new AdminModel()
                {
                    Id = adminData.Id,
                    Name = adminData.Name,
                };
                _context.BookStoreAdmins.Add(admin);
                _context.SaveChanges();
                   TempData["successMessage"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            else {
                TempData["errorMessage"] = "Model data is not valid";
                return View();
           }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteAdmin()
        {
            return View();

        }
    }
}


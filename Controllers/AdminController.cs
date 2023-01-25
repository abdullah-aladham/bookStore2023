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
        //[HttpPost]
        public IActionResult AddAdmin(AdminViewModel adminData)
        {

            try
            {
                if (ModelState.IsValid)
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
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //[HttpPost]
        public IActionResult UpdateAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteAdmin()
        {
            return View();

        }
        //[HttpGet]
        public IActionResult Edit(int Id) {
            try
            {
                var admin = _context.BookStoreAdmins.SingleOrDefault(x => x.Id == Id);
                if (admin != null)
                {
                    var adminView = new AdminViewModel()
                    {
                        Id = admin.Id,
                        Name = admin.Name,
                    };
                    return View(adminView);
                }
                else
                {
                    TempData["errorMessage"] = "Admin details are not avaliable with Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"]=ex.Message;
                return RedirectToAction("Index");
            }
            

        }
        //[HttpPost]
        public IActionResult EditAdmin(AdminViewModel adminData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var admin = new AdminModel()
                    {
                        Id = adminData.Id,
                        Name = adminData.Name,
                    };
                    _context.BookStoreAdmins.Update(admin);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Admin data updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errormessage"] = "Something Wrong happened";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["errormessage"] = e.Message;
                return View();
            }

        }
        
    }
}


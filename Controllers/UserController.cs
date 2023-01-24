using BookStore2.Data;
using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.BookStoreUsers.ToList();
            List<UserViewModel> userList = new List<UserViewModel>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var UserViewModel = new UserViewModel()
                    {
                        Id = user.Id,
                        Name = user.Name
                    };
                    userList.Add(UserViewModel);
                }
                return View(userList);
            }
            return View(userList);
        }
        public IActionResult AddUser(UserViewModel userData)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel();
                {
                    Id = userData.Id,
                    Name = userData.Name,
                };
                _context.BookStoreAdmins.Add(user);
                _context.SaveChanges();
                TempData["successMessage"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Model data is not valid";
                return View();
            }
            return View();
        }
    }
}

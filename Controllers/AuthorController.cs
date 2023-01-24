using BookStore2.Data;
using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var authors = _context.BookStoreAuthors.ToList();
            List<AuthorViewModel> authorList = new List<AuthorViewModel>();

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    var AuthorViewModel = new AuthorViewModel()
                    {
                        Id = author.Id,
                        Name = author.Name
                    };
                    authorList.Add(AuthorViewModel);
                }
                return View(authorList);
            }
            return View(authorList);
        }
        
        public IActionResult AddAuthor(AuthorViewModel authorData)
        {
            if (ModelState.IsValid)
            {
                var author = new AdminModel()
                {
                    Id = authorData.Id,
                    Name = authorData.Name,
                };
                _context.BookStoreAdmins.Add(author);
                _context.SaveChanges();
                TempData["successMessage"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Model data is not valid";
                return View();
            }

          // return View();
        }
        [HttpPost]
        public IActionResult UpdateAuthor()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor()
        {
            return View();
        }




    }
}

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
                var author = new AuthorModel()
                {
                    Id = authorData.Id,
                    Name = authorData.Name,
                };
                _context.BookStoreAuthors.Add(author);
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
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var author = _context.BookStoreAuthors.SingleOrDefault(x => x.Id == Id);
                if (author != null)
                {
                    var authorView = new AuthorViewModel()
                    {
                        Id = author.Id,
                        Name = author.Name
                    };
                    return View(authorView);
                }
                else
                {
                    TempData["errorMessage"] = $"Author details are not avaliable with Id : {Id}";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["error Message"] = e.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult UpdateAuthor(AuthorViewModel authorUpdateData)
        {
            if (ModelState.IsValid)
            {
                var author = new AuthorModel() { 
                    Id=authorUpdateData.Id,
                Name=authorUpdateData.Name
                };
                _context.BookStoreAuthors.Update(author);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Author Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Couldn't update data";
                return View();
            }
            //return View();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor()
        {
            return View();
        }




    }
}

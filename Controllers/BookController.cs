using Microsoft.AspNetCore.Mvc;
using BookStore2.Data;
using BookStore2.Models;

namespace BookStore2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var books = _context.BookStoreAdmins.ToList();
            List<BookViewModel> bookList = new List<BookViewModel>();

            if (books != null)
            {
                foreach (var book in books)
                {
                    var BookViewModel = new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Name
                    };
                    bookList.Add(BookViewModel);
                }
                return View(bookList);
            }
            return View(bookList);
        }
        public IActionResult AddBook(BookViewModel bookData)
        {
            if (ModelState.IsValid)
            {
                var book = new BookModel()
                {
                    Id = bookData.Id,
                    Title = bookData.Title,
                };
                _context.BookStoreAdmins.Add(book);
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

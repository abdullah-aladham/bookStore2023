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
                _context.Books.Add(book);
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
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var author = _context.Books.SingleOrDefault(x => x.Id == Id);
                if (author != null)
                {
                    var BookView = new BookViewModel()
                    {
                        Id = author.Id,
                        Title = author.Title
                    };
                    return View(BookView);
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
        public IActionResult UpdateBook(BookViewModel bookUpdateData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = new BookModel()
                    {
                        Id = bookUpdateData.Id,
                        Title = bookUpdateData.Title
                    };
                    _context.Books.Update(book);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Author Updated Successfully";
                    return View();
                }
                else
                {
                    TempData["errorMessage"] = "Couldn't update data";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return RedirectToAction("Index");


            }
        }
        public IActionResult DeleteBook(int id) {
            return View();
        }
    }

}

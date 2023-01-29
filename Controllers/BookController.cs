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
            var books = _context.Books.ToList();
            List<BookViewModel> bookList = new List<BookViewModel>();

            if (books != null)
            {
                foreach (var book in books)
                {
                    var BookViewModel = new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title
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
                var book = _context.Books.SingleOrDefault(x => x.Id == Id);
                if (book != null)
                {
                    var BookView = new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title
                    };
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["errorMessage"] = $"book details are not avaliable with Id : {Id}";
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
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var book = _context.Books.SingleOrDefault(x => x.Id == Id);
                if (book != null)
                {
                    var bookView = new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                    };
                    return View(bookView);
                }
                else
                {
                    TempData["errorMessage"] = $"Book details are not avaliable with Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]//2
        public IActionResult DeleteBook(BookViewModel model)
        {
            try
            {
                var book = _context.Books.SingleOrDefault(x => x.Id == model.Id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Book deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Book details not avaliable with the Id:{model.Id}";
                    return RedirectToAction("index");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();

            }


        }



    
}

}

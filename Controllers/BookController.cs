using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

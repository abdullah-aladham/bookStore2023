using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

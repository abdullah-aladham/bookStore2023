using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult AddAdmin()
        {
            return View();
        } 
        public IActionResult UpdateAdmin()
        {
            return View();
        } 
        public IActionResult DeleteAdmin()
        {
            return View();
        } public IActionResult ViewAdmin()
        {
            return View();
        }
    }
}

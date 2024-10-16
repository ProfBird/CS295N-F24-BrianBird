using Microsoft.AspNetCore.Mvc;

namespace BookReviews2024.Controllers
{
    public class AboutController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }
    }
}

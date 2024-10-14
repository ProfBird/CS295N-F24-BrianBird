using BookReviews2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviews2024.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Get the review objects and put them into a list.
            
            
            return View();
        }

        public IActionResult Review()
        {

        return View(); 
        }
    }
}

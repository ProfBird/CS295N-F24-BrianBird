using BookReviews2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviews2024.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Get the review objects and put them into a list.
            Review model = new Review();
            model.Reviewer = new AppUser();
            model.Book = new Book();
            return View(model);
        }

        public IActionResult Review()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            model.ReviewDate = DateTime.Now;  // Add date and time to the model
            return View("Index", model);
        }
    }
}

using BookReviews2024.Data;
using BookReviews2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviews2024.Controllers
{
    public class ReviewsController : Controller
    {
        // private instance variable
        IReviewRepository repo;

        // constructor
        public ReviewsController(IReviewRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
                var reviews = repo.GetReviews();
                return View(reviews);
        }

        public IActionResult Review()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            model.ReviewDate = DateTime.Now;  // Add date and time to the model
            repo.StoreReview(model);
            return RedirectToAction("Index");
        }
    }
}

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

        public IActionResult Filter(string reviewer, string date)
        {
            var reviews = repo.GetReviews()
                .Where(r => reviewer == null || r.Reviewer.Name == reviewer)
                .Where(r => date == null || r.ReviewDate ==  DateOnly.Parse(date))
                .ToList();
/*
            var reviews = repo.GetReviews()
                .Where(r => r.Reviewer.Name == reviewer|| reviewer == null)
                .ToList();*/
            return View("Index", reviews);
        }

        public IActionResult Review()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            model.ReviewDate = DateOnly.FromDateTime(DateTime.Today);  // Add date and time to the model
            if (repo.StoreReview(model) > 0)
            {
                return RedirectToAction("Index", new { reviewId = model.ReviewId });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the review.";
                return View();
            }
        }
    }
}

using BookReviews2024.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviews2024.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public ReviewRepository(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }
        
        public List<Review> GetReviews()
        {
            var reveiws = context.Reviews
              .Include(review => review.Reviewer) // returns Reivew.AppUser object
              .Include(review => review.Book) // returns Review.Book object
              .ToList<Review>();
            return reveiws;
        }

        public Review GetReviewById(int id)
        {
            var review = context.Reviews
              .Include(review => review.Reviewer) // returns Reivew.AppUser object
              .Include(review => review.Book) // returns Review.Book object
              .Where(review => review.ReviewId == id)
              .SingleOrDefault();
            return review;
        }

        public int StoreReview(Review model)
        {
            model.ReviewDate = DateTime.Now;
            model.Book.Publisher = ""; // TODO: Add a field for this to the form
            context.Reviews.Add(model);
            return context.SaveChanges();  // returns a positive value if succussful
        }

    }
}

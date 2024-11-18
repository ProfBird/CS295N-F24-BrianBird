using BookReviews2024.Models;

namespace BookReviews2024.Data
{
    public interface IReviewRepository
    {
        public List<Review> GetReviews();
        public Review GetReviewById(int id); // Returns a model object
        public int StoreReview(Review model);  // Saves a model object to the db
    }
}

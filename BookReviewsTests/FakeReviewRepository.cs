using BookReviews2024.Data;
using BookReviews2024.Models;

namespace BookReviewsTests
{
    public class FakeReviewRepository : IReviewRepository
    {
        private List<Review> reviews = new List<Review>();  // Use a list as a data store

        public Review GetReviewById(int id)
        {
            Review review = reviews.Find(r => r.ReviewId == id);
            return review;
        }


        public int StoreReview(Review model)
        {
            int status = 0;
            if (model != null && model.Reviewer != null)
            {
                model.ReviewId = reviews.Count + 1;
                reviews.Add(model);
                status = 1;
            }
            return status;
        }

        List<Review> IReviewRepository.GetReviews()
        {
            return reviews;
        }
    }
}
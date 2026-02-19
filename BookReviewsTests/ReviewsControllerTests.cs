using BookReviews2024.Controllers;
using BookReviews2024.Data;
using BookReviews2024.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewsTests
{
    public class ReviewControllerTests
    {
        IReviewRepository _repo = new FakeReviewRepository();
        ReviewsController _controller;
        Review _review = new Review();

        public ReviewControllerTests()
        {
            _controller = new ReviewsController(_repo);
        }


        [Fact]
        public void Review_PostTest_Success()
        {
            // arrange: done in the constructor

            // act
            _review.Reviewer = new AppUser();
            _review.ReviewedBook = new Book();
            var result = _controller.Review(_review);

            // assert: check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }


        [Fact]
        public void Review_PostTest_Failure()
        {
            // arrange: done in the constructor

            // act
            var result = _controller.Review(_review);

            // assert: check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}

using BookReviews2024.Models;
using System.Runtime.Intrinsics.X86;
using System;

namespace BookReviews2024.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Reviews.Any())  // this is to prevent adding duplicate data
            {
                // Create User objects
                AppUser reviewer1 = new AppUser { Name = "Emma Watson" };
                AppUser reviewer2 = new AppUser { Name = "Brian Bird" };

                // Queue up user objects to be saved to the DB
                context.AppUsers.Add(reviewer1);
                context.AppUsers.Add(reviewer2);
                context.SaveChanges();  // Saving adds UserId to User objects

                // Create Book objects
                Book book1 = new Book { Title = "The Dispossed", Author = "Ursula Le Guine", Publisher = "TLR" };
                Book book2 = new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Publisher = "Penguin" };

                // Queue up user objects to be saved to the DB
                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges();  // Saving adds UserId to User objects

                Review review = new Review
                {
                    ReviewedBook = book1,
                    ReviewText = "Great book, a must read!",
                    Reviewer = reviewer1,
                    ReviewDate = DateTime.Parse("11/1/2020")
                };

                context.Reviews.Add(review);  // queues up a review to be added to the DB
                review = new Review
                {
                    ReviewedBook = book2,
                    ReviewText = "Wonderful book, a classic!",
                    Reviewer = reviewer2,
                    ReviewDate = DateTime.Parse("11/30/2020")
                };

                context.Reviews.Add(review);
                context.SaveChanges(); // stores all the reviews in the DB
            }

        }

    }

}

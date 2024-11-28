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

                // Queue up book objects to be saved to the DB
                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges();  // Saving adds UserId to User objects

                Review review = new Review
                {
                    ReviewedBook = book1,
                    ReviewText = "Great book, a must read!",
                    Reviewer = reviewer1,
                    ReviewDate = DateOnly.Parse("11/1/2020")
                };

                context.Reviews.Add(review);  // queues up a review to be added to the DB
                review = new Review
                {
                    ReviewedBook = book2,
                    ReviewText = "Wonderful book, a classic!",
                    Reviewer = reviewer2,
                    ReviewDate = DateOnly.Parse("11/30/2020")
                };
                context.Reviews.Add(review);
                
                /* Add four more reviews */

                Book book = new Book { Author = "Samuel Shallabarger", Title = "Prince of Foxes", Publisher = "Doubleday" };
                context.Books.Add(book);
                context.SaveChanges();

                review = new Review
                {
                    ReviewedBook = book,
                    ReviewText = "Great book, a must read!",
                    Reviewer = new AppUser { Name = "Emma Watson" },
                    ReviewDate = DateOnly.Parse("11/1/2020")
                };
                context.Reviews.Add(review);  // queues up the review to be added to the DB

                review = new Review
                {
                    ReviewedBook = book,
                    ReviewText = "I love the clever, witty dialog",
                    Reviewer = new AppUser { Name = "Daniel Radliiffe" },
                    ReviewDate = DateOnly.Parse("11/15/2020")
                };
                context.Reviews.Add(review);

                // My next two reviews will be by the same user, so I will create
                // the user object once and store it so that both reviews will be
                // associated with the same entity in the DB.

                AppUser reviewerBrianBird = new AppUser() { Name = "Brian Bird" };
                context.AppUsers.Add(reviewerBrianBird);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                review = new Review
                {
                    ReviewedBook = new Book
                    {
                        Title = "Virgil Wander",
                        Author = "Lief Enger",
                        Publisher = "Grove Press"
                    },
                    ReviewText = "Wonderful book, written by a distant cousin of mine.",
                    Reviewer = reviewerBrianBird,
                    ReviewDate = DateOnly.Parse("11/30/2020")
                };
                context.Reviews.Add(review);

                review = new Review
                {
                    ReviewedBook = new Book
                    {
                        Title = "Ivanho",
                        Author = "Sir Walter Scott",
                        Publisher = "Penguin"
                    },
                    ReviewText = "It was a little hard going at first, but then I loved it!",
                    Reviewer = reviewerBrianBird,
                    ReviewDate = DateOnly.Parse("11/1/2020")
                };
                context.Reviews.Add(review);
                
                context.SaveChanges(); // stores all the reviews in the DB
            }

        }

    }

}

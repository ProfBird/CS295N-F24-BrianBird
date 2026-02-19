namespace BookReviews2024.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Isbn { get; set; }
        public string Publisher { get; set; }
        public DateTime PubDate { get; set; }
    }
}

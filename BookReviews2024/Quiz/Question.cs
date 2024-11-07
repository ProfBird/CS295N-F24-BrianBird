namespace BookReviews2024.BookQuiz
{
    public class Question
    {
        public string Q { get; set; }  // question
        public string A { get; set; }  // right answer
        public string UserA { get; set; } // user's answer
        public Boolean isRight { get; set; } // was the user's answer right
    }
}

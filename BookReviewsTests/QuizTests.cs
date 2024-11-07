using BookReviews2024.BookQuiz;

namespace BookReviewsTests
{
    public class QuizTests
    {
        private Quiz _quiz = new Quiz();
        
        [Fact]
        public void CheckCorrectAnswer()
        {
            // Arrange
            Question q1 = new Question()
            {
                Q = "Who is the author of Lord of the Rings?",
                A = "J.R.R. Tolkien",
                UserA = "J.R.R. Tolkien"
            };
            _quiz.Questions.Add(q1);
                
            // Act
            bool isCorrect = _quiz.CheckAnswer(_quiz.Questions.Last());
            // Assert
            Assert.True(isCorrect);
        }

        [Fact]
        public void CheckWrongAnswer()
        {
            // Arrange
            Question q2 = new Question()
            {
                Q = "Who is the author of Lord of the Rings?",
                A = "J.R.R. Tolkien",
                UserA = "Ray Bradbury"
            };
            _quiz.Questions.Add(q2);
            
            // Act
            bool isCorrect = _quiz.CheckAnswer(_quiz.Questions.Last());
            // Assert
            Assert.False(isCorrect);
        }
    }
}
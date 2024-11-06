using BookReviews2024.BookQuiz;

namespace BookReviewsTests
{
    public class QuizTests
    {
        Quiz quiz = new Quiz();

        public QuizTests() {
            
            Question q1 = new Question()
            {
                Q = "Who is the author of Lord of the Rings?",
                A = "J.R.R. Tolkien",
                UserA = "J.R.R. Tolkien"
            };
            quiz.Questions.Add(q1);

            Question q2 = new Question()
            {
                Q = "Who is the author of Lord of the Rings?",
                A = "J.R.R. Tolkien",
                UserA = "Ray Bradbury"
            };
            quiz.Questions.Add(q2);
        }

        [Fact]
        public void checkCorrectAnswer()
        {
            // Arrange is done in the constructor

            // Act
            bool isCorrect = quiz.checkAnswer(quiz.Questions[0]);
            // Assert
            Assert.True(isCorrect);
        }

        [Fact]
        public void checkWrongAnswer()
        {
            // Arrange is done in the constructor

            // Act
            bool isCorrect = quiz.checkAnswer(quiz.Questions[1]);
            // Assert
            Assert.False(isCorrect);
        }

        [Fact]
        public void checkNumberQuestions()
        {
            // Arrange is done in the constructor
            // No act needed
            Assert.Equal(2, quiz.Questions.Count);
        }
    }
}
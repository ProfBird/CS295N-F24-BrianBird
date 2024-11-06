using System;

namespace BookReviews2024.BookQuiz
{
    public class Quiz
    {
        private List<Question> _questions = new List<Question>();

        public Quiz()
        {
            _questions.Add(new Question()
            {
                Q = "What is the longest book ever written?",
                A = "The Count of Monte Cristo",
                UserA = ""
            });

            _questions.Add(new Question()
            {
                Q = "Who is the author of the Harry Potter series ?",
                A = "J.K. Rowling",
                UserA = ""
            });

            _questions.Add(new Question()
            {
                Q = "What is the name of the world's largest bookstore chain?",
                A = "Barnes and Noble",
                UserA = ""
            });
        }

        public List<Question> Questions {
            get { return _questions; }
        }
        public bool checkAnswer(Question q)
        {
            return q.UserA == q.A;
        }
    }
}

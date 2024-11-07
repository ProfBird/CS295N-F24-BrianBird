using BookReviews2024.Models;
using BookReviews2024.BookQuiz;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookReviews2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Recommended()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Quiz()
        {
            Quiz model = new Quiz();
            return View(model);
        }

        [HttpPost]
        public IActionResult Quiz(string[] answers)
        {

            // Check the answers and send results back to the view
            Quiz model = new Quiz();
            for (int i = 0; i < answers.Length; i++)
            {
                string answer = answers[i];
                if (answer != null)
                {
                    Question q1 = model.Questions[i];
                    q1.UserA = answer;
                    q1.isRight = model.CheckAnswer(q1);
                }
            }
            
            return View(model);
        }
    }
}

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
        public IActionResult Quiz(string answer1, string answer2, string answer3)
        {

            // TODO: check the answers and send results back to the view
            Quiz model = new Quiz();
            Question q1 = model.Questions[0];
            q1.UserA = answer1;
            q1.isRight = model.checkAnswer(q1);

            Question q2 = model.Questions[1];
            q2.UserA = answer2;
            q2.isRight = model.checkAnswer(q2);

            Question q3 = model.Questions[2];
            q3.UserA = answer3;
            q3.isRight = model.checkAnswer(q3);

            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public static List<EmailModel> emails = new List<EmailModel>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(EmailModel model)
        {
            return View();
        }

        public IActionResult AddPost(EmailModel model)
        {
            try
            {
                EmailModel email = new EmailModel
                {
                    Email = model.Email,
                    Date = DateTime.Now
                };
                emails.Add(email);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Index(model);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
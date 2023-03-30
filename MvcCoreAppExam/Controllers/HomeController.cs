using Microsoft.AspNetCore.Mvc;
using MvcCoreAppExam.Models;
using System.Diagnostics;

namespace MvcCoreAppExam.Controllers
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

        [HttpPost]
        public IActionResult GetServerMessage()
        {
            var viewModel = new IndexViewModel();
            viewModel.ServerMessage = $"現在のサーバ時刻は{DateTime.Now}です。";
            return View("Index", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MvcCoreAppExam.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MvcCoreAppExam.Controllers
{
    /// <summary>
    /// 電卓アプリ画面コントローラ
    /// </summary>
    public class CalcController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private const string ViewName = "Calc";

        private CalcViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logger"></param>
        public CalcController(ILogger<HomeController> logger)
        {
            this.viewModel = new CalcViewModel();
            _logger = logger;
        }

        /// <summary>
        /// 初期表示アクション
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public IActionResult Index()
        {
            return View(ViewName);
        }


    }
}
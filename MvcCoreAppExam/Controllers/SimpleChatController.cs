using Microsoft.AspNetCore.Mvc;
using MvcCoreAppExam.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MvcCoreAppExam.Controllers
{
    public class SimpleChatController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private const string ViewName = "SimpleChat";

        public SimpleChatController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            return View(ViewName);
        }


        [HttpPost]
        public IActionResult SendMessage(string inputUserName, string inputMessage)
        {
            var viewModel = new SimpleChatViewModel();

            // 前回保存したメッセージリストがあれば復元する
            if (TempData.ContainsKey("MessageList"))
            {
                string? messageListJson = TempData["MessageList"] as string;
                if (!String.IsNullOrEmpty(messageListJson))
                {
                    viewModel.MessageList = 
                        JsonConvert.DeserializeObject<List<MessageListItem>>(messageListJson)
                            ?? new List<MessageListItem>();
                }
            }

            // 入力されたメッセージをリストに追加
            viewModel.MessageList.Add(new MessageListItem() { 
                SendTime = DateTime.Now, 
                Message = inputUserName,
                UserName = inputMessage,
            });

            TempData["MessageList"] = JsonConvert.SerializeObject(viewModel.MessageList);
            return View(ViewName, viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
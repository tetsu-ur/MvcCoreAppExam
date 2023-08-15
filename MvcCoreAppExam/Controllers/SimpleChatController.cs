using log4net;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAppExam.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MvcCoreAppExam.Controllers
{
    /// <summary>
    /// シンプルチャット画面コントローラ
    /// </summary>
    public class SimpleChatController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SimpleChatController));

        private const string ViewName = "SimpleChat";

        private SimpleChatViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logger"></param>
        public SimpleChatController()
        {
            this.viewModel = new SimpleChatViewModel();
        }

        /// <summary>
        /// 初期表示アクション
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public IActionResult Index()
        {
            Log.Debug("デバッグメッセージ");
            Log.Info("インフォメーションメッセージ");
            // 保存されたメッセージリストをViewModelに復元する
            this.ResumeViewModel();
            this.viewModel.EnableUseNameDialog = true;

            return View(ViewName, viewModel);
        }

        /// <summary>
        /// 保存されたメッセージリストをViewModelに復元する
        /// </summary>
        private void ResumeViewModel()
        {
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
        }

        /// <summary>
        /// 送信アクション
        /// </summary>
        /// <param name="inputUserName">ユーザ名</param>
        /// <param name="inputMessage">入力メッセージ</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendMessage(string inputUserName, string inputMessage)
        {
            this.viewModel.EnableUseNameDialog = false;

            // 保存されたメッセージリストをViewModelに復元する
            this.ResumeViewModel();

            // 入力されたメッセージをリストに追加
            viewModel.MessageList.Add(new MessageListItem() { 
                SendTime = DateTime.Now, 
                Message = inputMessage,
                UserName = inputUserName,
                From　= MessageFrom.MySelf,
            });;

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
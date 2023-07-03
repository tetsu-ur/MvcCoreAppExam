namespace MvcCoreAppExam.Models
{
    /// <summary>
    /// SimpleChat 画面 ViewModel
    /// </summary>
    [Serializable]
    public class SimpleChatViewModel
    {

        /// <summary>
        /// ユーザ名入力ダイアログを表示するか
        /// </summary>
        public bool EnableUseNameDialog { get; set; }

        /// <summary>
        /// メッセージリスト
        /// </summary>
        public List<MessageListItem> MessageList { get; set; } = new List<MessageListItem>();
    }
}

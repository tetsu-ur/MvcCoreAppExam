namespace MvcCoreAppExam.Models
{
    /// <summary>
    /// SimpleChat 画面 ViewModel
    /// </summary>
    [Serializable]
    public class SimpleChatViewModel
    {
        /// <summary>
        /// メッセージリスト
        /// </summary>
        public List<MessageListItem> MessageList { get; set; } = new List<MessageListItem>();
    }
}

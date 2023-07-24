namespace MvcCoreAppExam.Models
{
    /// <summary>
    /// 電卓アプリ画面 ViewModel
    /// </summary>
    [Serializable]
    public class CalcViewModel
    {

        /// <summary>
        /// メッセージリスト ※チャットの内容を引用
        /// </summary>
        public List<MessageListItem> MessageList { get; set; } = new List<MessageListItem>();
    }
}

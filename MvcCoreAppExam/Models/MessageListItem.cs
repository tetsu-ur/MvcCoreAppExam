namespace MvcCoreAppExam.Models
{

    /// <summary>
    /// メッセージの送信元
    /// </summary>
    public enum MessageFrom
    {
        /// <summary>自分自身</summary>
        MySelf,
        /// <summary>自分以外</summary>
        Other,
    }

    /// <summary>
    /// メッセージリスト要素
    /// </summary>
    [Serializable]
    public class MessageListItem
    {
        /// <summary>送信日時</summary>
        public DateTime SendTime { get; set; }

        /// <summary>ユーザ名</summary>
        public string? UserName { get; set; }

        /// <summary>メッセージ</summary>
        public string? Message { get; set; }

        /// <summary>メッセージの送り元</summary>
        public MessageFrom? From { get; set; }

    }
}

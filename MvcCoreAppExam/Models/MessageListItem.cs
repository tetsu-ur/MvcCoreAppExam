namespace MvcCoreAppExam.Models
{
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

    }
}

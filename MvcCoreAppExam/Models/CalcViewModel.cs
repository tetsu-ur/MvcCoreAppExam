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

        /// <summary>これまでに入力された値</summary>
        public string? InputValues { get; set; } = string.Empty;

        /// <summary>これまでの計算の合計値</summary>
        public int TotalValue { get; set; }

        /// <summary>直近で入力された演算子</summary>
        public string? PreviousOperator { get; set;}

        /// <summary>液晶画面に表示する値</summary>
        public string DisplayValue { get; set;} = "0";
    }
}

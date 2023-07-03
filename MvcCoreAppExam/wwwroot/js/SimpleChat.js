/* ----------------------------------------------------- */
/* SimpleChat Javascript ファイル                          */
/* ----------------------------------------------------- */

/* 初期処理
 *
 * ドキュメントが完全に読み込まれてDOMが使用可能な状態になったときに実行されるファンクション
 * 次の記載方法のショートハンド（短縮形）で、意味は同じ。
 *   $(document).ready(function() {
 *   });
 */
$(function () {

    // ユーザ名入力ダイアログの「決定」ボタンイベントハンドラ設定
    $("#username-submit").click(function () {
        var inputValue = $("#username-input").val();
        //alert('Input value is: ' + inputValue);

        // ユーザ名入力ダイアログを非表示化
        $('#username-dialog').addClass('dialog-unvisible');

        // ユーザ名をhiddenに設定
        $("#InputUserName").val(inputValue);

        alert('InputUserName value is: ' + $("#InputUserName").val);

    });
});

function setUserName(userName) {

    alert('userName = ' + userName);
}

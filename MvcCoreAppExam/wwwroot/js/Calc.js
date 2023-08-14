/* ----------------------------------------------------- */
/* Calc Javascript ファイル                          */
/* ----------------------------------------------------- */

//function get_calc(button) {
//    //ボタンで押した値をbtnへ代入
//    var btn = button.value;
//    //コンソールへの表示(押したボタンの種類)
//    console.log("押したボタン＝"+ btn);

//    if (button.value == "C") {
//        //　C　なら全部消す　→　今まで足していた数字
//        document.dentaku.display.value = "0";

//    } else if (button.value == "=") {
//        //　＝　なら全部足す　→　今まで足していた数字
//        console.log("＝なので全部足す！");
//        //画面の文字を格納する
//        var displayStr = document.dentaku.display.value;
//        var displayReplace_1 = displayStr.replace(/×/g, "*");
//        var displayReplace_2 = displayReplace_1.replace(/÷/g, "/");
//        var goukei = keisan(displayReplace_2);
//        document.dentaku.display.value = goukei;

//    } else {
//        //画面の最後の文字を格納する
//        var displayValue = document.dentaku.display.value;
//        if (displayValue.length > 0) {
//            var lastCharacter = displayValue[displayValue.length - 1];
//            console.log(lastCharacter);
//        } else {
//            console.log("文字列が空です。");
//        }

//        //数字、記号の場合
//        //画面が0か00だったら
//        if (document.dentaku.display.value === "0" || document.dentaku.display.value === "00") {
//            //画面が0、00で　さらに押したボタンが0か00なら0を表示
//            document.dentaku.display.value = btn;
//            if (button.value == "0" || button.value == "00") {
//                document.dentaku.display.value = "0";
//            } else {
//                //それ以外は押したボタンを表示
//                document.dentaku.display.value = btn;
//            }

//        //画面が0、00以外のとき
//        //画面の末が記号の場合
//        } else if (lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "÷" || lastCharacter == "×") {
//            console.log("最後の文字は記号です");
//            if (button.value === "0" || button.value === "00") {
//                //画面上の末が記号だったとき0と00は押せない
//                return;
//            } else if (button.value == "+" || button.value == "-" || button.value == "÷" || button.value == "×") {
//                //画面上の末が記号だったとき記号は押せない
//                return;
//            } else if (button.value == ".") {
//                document.dentaku.display.value += "0."
            
//            } else {
//                //画面への表示
//                document.dentaku.display.value += btn;
//            }
//        //画面の末が記号以外のとき
//        } else {
//            //画面への表示
//            document.dentaku.display.value += btn;
//            console.log("lastCharacter" + lastCharacter);
//        }
//    }
//}

// new Function() コンストラクタを使用して、動的に与えられた文字列 obj をJavaScriptのコードとして評価する方法
function keisan(obj) {
    //() を使って、生成された関数を即時に実行する
    return new Function('return (' + obj + ')')();
}


/**
 * 入力されたキーの値をHiddenタグ「ClickedValue」に設定してsubmitする
 *
 * @param {string} actionUrl - アクションURL
 * @param {object} objInput - 押下されたボタンのエレメント
 */
function submitInputKey(actionUrl, objInput) {
    // 押下されたボタンの値をHiddenタグ「InputKey」にセット
    let ObjInputkey = document.getElementById('ClickedValue');
    ObjInputkey.value = objInput.value;

    // コントローラへSubmit
    let objForm = document.getElementById('dentaku');
    objForm.method = 'POST';
    objForm.action = actionUrl;
    objForm.submit();
}

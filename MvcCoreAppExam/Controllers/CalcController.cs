using Microsoft.AspNetCore.Mvc;
using MvcCoreAppExam.Models;
using Newtonsoft.Json;

using System.Diagnostics;
using System.Reflection;

namespace MvcCoreAppExam.Controllers
{
    /// <summary>
    /// 電卓アプリ画面コントローラ
    /// </summary>
    public class CalcController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private const string ViewName = "Calc";

        private CalcViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logger"></param>
        public CalcController(ILogger<HomeController> logger)
        {
            this.viewModel = new CalcViewModel();

            _logger = logger;
        }

        /// <summary>
        /// 初期表示アクション
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public IActionResult Index()
        {
            return View(ViewName, this.viewModel);
        }

        /// <summary>
        /// 数値キーの入力を処理するアクション
        /// </summary>
        /// <param name="clickedValue">押下された数値ボタンの値</param>
        /// <returns></returns>
        public IActionResult InputKey(string clickedValue)
        {
            // TempDataに保存されたViewModelを復元する
            this.ResumeViewModel();
            // 入力された数値を結合する
            this.viewModel.InputValues += clickedValue;            
            // 表示用の値を設定する
            this.viewModel.DisplayValue = this.viewModel.InputValues;
            // ViewModelを次回の処理用にTempDataに保存
            TempData["CalcViewModel"] = JsonConvert.SerializeObject(viewModel);
            // Viewに返却　　　　　　　　　
            return View(ViewName, this.viewModel);
        }

        /// <summary>
        /// 演算子の入力を処理するアクション
        /// </summary>
        /// <remarks>
        /// これまでの合計値(TotalValue)と直近で入力された演算子(PreviousOperator)を
        /// もとに計算を実施します。
        /// </remarks>
        /// <param name="clickedValue">押下された演算子ボタンの値</param>
        /// <returns></returns>
        public IActionResult InputOperator(string clickedValue)
        {
            //押した記号で処理を分けていく
            //CならInputValuesを0にする
            if (clickedValue == "C")
            {
                // TempDataに保存されたViewModelを復元する
                this.ResumeViewModel();
                this.viewModel.InputValues = "0";
            } else
            {
                //演算子に値が入っていなかったら画面の数字をTotalValueに保存する
                if (string.IsNullOrEmpty(this.viewModel.PreviousOperator))
                {
                    // TempDataに保存されたViewModelを復元する
                    this.ResumeViewModel();
                    //これまでの計算の合計値に値を格納する
                    this.viewModel.TotalValue = this.viewModel.InputValues;
                    // 入力された数値を結合する
                    this.viewModel.InputValues += clickedValue;
                    //直近で入力された演算子を記録する
                    this.viewModel.PreviousOperator = clickedValue;
                    
                }
                //直近で入力された演算子に値が入っていたら計算する
                else
                {
                    if (this.viewModel.PreviousOperator == "+")
                    {
                        //TotalValue＋DisplayValue
                        this.viewModel.TotalValue += this.viewModel.DisplayValue;

                    } else if (this.viewModel.PreviousOperator == "-")
                    {
                        //TotalValue-DisplayValue
                        this.viewModel.TotalValue = this.viewModel.TotalValue - this.viewModel.DisplayValue;
                    } else if (this.viewModel.PreviousOperator == "×")
                    {
                        //TotalValue×DisplayValue
                        this.viewModel.TotalValue = this.viewModel.TotalValue * this.viewModel.DisplayValue;
                    }
                    else if (this.viewModel.PreviousOperator == "÷")
                    {
                        //TotalValue÷DisplayValue
                        this.viewModel.TotalValue = this.viewModel.TotalValue / this.viewModel.DisplayValue;
                    }
                }
            }
            // 表示用の値を設定する
            this.viewModel.DisplayValue = this.viewModel.TotalValue;
            // ViewModelを次回の処理用にTempDataに保存
            TempData["CalcViewModel"] = JsonConvert.SerializeObject(viewModel);

            // Viewに返却　　　　　　　　　
            return View(ViewName, this.viewModel);
            //押した記号で処理を分けていく
        }

        /// <summary>
        /// イコール "=" の入力を処理するアクション
        /// </summary>
        /// <param name="clickedValue">押下されたイコールボタンの値 "="</param>
        /// <returns></returns>
        public IActionResult InputEqual(string clickedValue)
        {
            throw new NotSupportedException("まだ実装していません。実装よろしく。");
        }

        /// <summary>
        /// TempDataに保存されたViewModelを復元する
        /// </summary>
        private void ResumeViewModel()
        {
            if (TempData.ContainsKey("CalcViewModel"))
            {
                string? viewModelJson = TempData["CalcViewModel"] as string;
                if (!String.IsNullOrEmpty(viewModelJson))
                {
                    viewModel =
                        JsonConvert.DeserializeObject<CalcViewModel>(viewModelJson)
                            ?? new CalcViewModel();
                }
            }
        }

    }
}
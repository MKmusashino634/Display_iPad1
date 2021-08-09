
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DisplayMK2
{
    using DisplayMK2.ViewModels;
    using DisplayMK2.Views;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //ウィンドウをインスタンス化
            var w = new MainView();

            //ウィンドウに対する ViewModel をインスタンス化
            var vm = new MainViewModel();

            //ウィンドウに対する ViewModel をデータコンテキスト化 = 何らかの制御情報化
            //MainViewウィンドウはMainViewModelを従える
            w.DataContext = vm;

            //ウィンドウの表示
            w.Show();
        }
    }
}

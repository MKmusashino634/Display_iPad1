using System.Windows;
using DisplayMK1.ViewModels;//これがミソ！！
using DisplayMK1.Views;//これがミソ！！

namespace DisplayMK1
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //ウィンドウをインスタンス化
            MainView w = new MainView();

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

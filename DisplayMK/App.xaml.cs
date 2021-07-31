using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YKWpfIntroduction.Practices
{
    using YKWpfIntroduction.Practices.ViewModels;
    using YKWpfIntroduction.Practices.Views;

    /// <summary>
    /// Interaction logic for App.xaml
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
            w.DataContext = vm;

            //ウィンドウの表示
            w.Show();
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DisplayMK1
{
    ///<summary>
    ///]MainView ウィンドウに対するデータコンテキストを表す
    ///</summary>
    internal abstract class NotificationObject : INotifyPropertyChanged
    {
        #region INotifyPropertyCanged の実装
        ///<summary>
        ///プロパティ変更で発生
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        ///<summary>
        ///PropertyChangedイベントを発行
        ///</summary>
        ///<param name="propertyName">プロパティ値に変更があったプロパティ名を指定する</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ///<summary>
        ///<typeparam name="T">プロパティの型</typeparam>
        ///<param name="target="">変更するプロパティの実体をref指定する</param>s
        ///<param name="value"">変更後の値の指定</param>
        ///<param name="propertyName"">プロパティ名の指定</param>
        ///<returns>変更ありならtrue、bool型は条件により真偽を返す型</returns>
        ///メソッドに引数を渡す方法に、値渡しと参照渡しがある。
        ///</summary>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(target, value)) return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        #endregion INotifyPropertyCanged の実装
    }
}

/*ワンポイント 3.4：System.Diagnostics.Debug クラスでデバッグコードを書くようにしよう
 * System.Console クラスの WriteLine() メソッドでも同様に出力ウィンドウにメッセージを出力させることできるが、
 * Release モードでもどこかにメッセージが出力されることになる。
 * コード上で "System.Diagnostics.Debug.WriteLine" と記述した後、"Debug" の部分に
 * キーボードカーソルを置いてから F12 キーを押すと Debug クラスの定義を覗くことができる。
 * 開いた直後はすべてアウトラインが閉じているので、□+ をクリックして
 * アウトラインを開くと各メソッドの概要などのコメントが見えるようになる。
 * その中で、メソッドの定義の真上の行に必ず "[Conditional("DEBUG")]" が付いていることが確認できる。
 */

/* INotifyPropertyChanged インターフェースは PropertyChanged イベントを持つインターフェースである。
 * プロパティ値に変更があったタイミングで発行することで、プロパティ変更を UI 側へ通知することができる。
 * このため、イベント発行をおこなう RaisePropertyChanged() メソッドを定義し、
 * 各プロパティ値が変更されたタイミングでこのメソッドを呼び出す。
 */

/* ワンポイント 3.5：#region ～ #endregion でアウトライン機能を使いこなせ
 * Visual Studio で C# コーディングをするとき、#region ～ #endregion で括ると、
 * 括ったコードを折り畳むことができるようになる。
 * また、Visual Stuido には拡張機能を追加することができるが、
 * 「C# outline 2013」という拡張機能を追加すると、
 * すべての "{" ～ "}" で囲まれた部分をアウトライン化される。
 * 拡張機能は「ツール」→「拡張機能と更新プログラム」メニューで開くダイアログで、
 * ツリーメニューから「オンライン」を選択して「C# outline 2013」を検索すると設定できる。
 */

/* ワンポイント 3.6：データバインディングの同期タイミングは UpdateSourceTrigger で変更できる 
 * TextBox コントロールの Text プロパティの同期タイミングはデフォルトではフォーカスを失ったときである。
 * XAML でデータバインディングの設定をおこなうとき、 
 * <TextBox Text="{Binding InputString, UpdateSourceTrigger=PropertyChanged}" /> 
 * とすると、テキストを入力した直後に同期されるため、
 * フォーカスを移動させなくてもデータコンテキストに変更通知されるようになる。
 * 結果的に、テキストを入力した直後に表示が反映されるようになる。
 */

namespace DisplayMK2
{
    using System;
    using System.Windows.Input;

    internal class DelegateCommand : ICommand
    {
        //Action<object> や Func<object, bool> クラスはデリゲートと呼ばれる。
        //メソッドの参照えおする。

        ///<simmary>
        ///コマンド実行時の処理内容を保持
        ///</simmary>
        private readonly Action<object> _execute;

        ///<simmary>
        ///コマンド実行可能判別の処理内容を保持
        ///</simmary>
        private readonly Func<object, bool> _canExecute;

        ///<summary>
        ///新しいインスタンスの作成
        ///</summary>
        ///<param name="execute">コマンド実行処理の指定</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null) { }

        ///<summary>
        ///新しいインスタンスの作成
        ///</summary>
        ///<param name="execute">コマンド実行処理の指定</param>
        ///<param name="canExecute">コマンド実行可能判別処理を指定</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommand の実装

        ///<summary>
        ///コマンドが実行可能判別処理の実行
        ///</summary>
        ///<param name="parameter">判別処理のパラメータ</param>
        ///<retuens>実行可能でtrue</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        ///<summary>
        ///実行可能判別処理の状態の変化により発生
        ///</summary>
        public event EventHandler CanExecuteChanged;

        ///<summary>
        ///CanExecuteChanged イベントの発行
        ///</summary>
        public void RaiseCanExecuteChanged()
        {
            /*
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
             */
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        ///<summary>
        ///コマンド実行後の処理
        ///</summary>
        ///<param name="parameter">コマンドのパラーメータを指定</param>
        public void Execute(object parameter)
        {
            this._execute?.Invoke(parameter);
        }

        #endregion  ICommand の実装
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

/* アンダーバーは、プロパティ変数など、直接参照して欲しくない変数に目印でつけたりする。
 */


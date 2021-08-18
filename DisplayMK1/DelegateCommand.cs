using System;
using System.Windows.Input;

namespace DisplayMK1
{
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

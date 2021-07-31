namespace YKWpfIntroduction.Practices.ViewModels
{
    ///<summary>
    ///]MainView ウィンドウに対するデータコンテキストを表す
    ///</summary>
    internal class MainViewModel
    {
        private string _upperString;
        ///<simmary>
        ///大文字にする
        ///</simmary>
        public string UpperString
        {
            get { return this._upperString; }
            private set {
                if (this._upperString != value) { this._upperString = value; }
            }
        }

        private string _InputString;
        ///<summary>
        ///入力文字列の取得、設定
        ///</summary>
        public string InputString
        {
            get { return this._InputString; }
            set {
                if (this._InputString != value) {
                    this._InputString = value;

                    //入力された文字列を大文字に変換
                    this.UpperString = this._InputString.ToUpper();

                    //出力ウィンドウに表示
                    System.Diagnostics.Debug.WriteLine("大文字=" + this.UpperString);
                    //DebugクラスはReleaseモードでは読み込まれない。
                }
            }
        }

        #region INotifyPropertyCanged の実装
        ///<summary>
        ///プロパティ変更で発生
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        ///<summary>
        ///PropertyChangedイベントを発行
        ///</summary>
        ///<param name="propertyName">プロパティ値に変更があったプロパティ名を指定する</param>
        private void RaisePropertyChanged(string propertyName)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyCanged の実装
    }
}
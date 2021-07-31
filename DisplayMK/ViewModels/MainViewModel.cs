namespace YKWpfIntroduction.Practices.ViewModels
{
    ///<summary>
    ///]MainView �E�B���h�E�ɑ΂���f�[�^�R���e�L�X�g��\��
    ///</summary>
    internal class MainViewModel
    {
        private string _upperString;
        ///<simmary>
        ///�啶���ɂ���
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
        ///���͕�����̎擾�A�ݒ�
        ///</summary>
        public string InputString
        {
            get { return this._InputString; }
            set {
                if (this._InputString != value) {
                    this._InputString = value;

                    //���͂��ꂽ�������啶���ɕϊ�
                    this.UpperString = this._InputString.ToUpper();

                    //�o�̓E�B���h�E�ɕ\��
                    System.Diagnostics.Debug.WriteLine("�啶��=" + this.UpperString);
                    //Debug�N���X��Release���[�h�ł͓ǂݍ��܂�Ȃ��B
                }
            }
        }

        #region INotifyPropertyCanged �̎���
        ///<summary>
        ///�v���p�e�B�ύX�Ŕ���
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        ///<summary>
        ///PropertyChanged�C�x���g�𔭍s
        ///</summary>
        ///<param name="propertyName">�v���p�e�B�l�ɕύX���������v���p�e�B�����w�肷��</param>
        private void RaisePropertyChanged(string propertyName)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyCanged �̎���
    }
}
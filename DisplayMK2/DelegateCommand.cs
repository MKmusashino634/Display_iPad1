namespace DisplayMK2
{
    using System;
    using System.Windows.Input;

    internal class DelegateCommand : ICommand
    {
        //Action<object> �� Func<object, bool> �N���X�̓f���Q�[�g�ƌĂ΂��B
        //���\�b�h�̎Q�Ƃ�������B

        ///<simmary>
        ///�R�}���h���s���̏������e��ێ�
        ///</simmary>
        private readonly Action<object> _execute;

        ///<simmary>
        ///�R�}���h���s�\���ʂ̏������e��ێ�
        ///</simmary>
        private readonly Func<object, bool> _canExecute;

        ///<summary>
        ///�V�����C���X�^���X�̍쐬
        ///</summary>
        ///<param name="execute">�R�}���h���s�����̎w��</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null) { }

        ///<summary>
        ///�V�����C���X�^���X�̍쐬
        ///</summary>
        ///<param name="execute">�R�}���h���s�����̎w��</param>
        ///<param name="canExecute">�R�}���h���s�\���ʏ������w��</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommand �̎���

        ///<summary>
        ///�R�}���h�����s�\���ʏ����̎��s
        ///</summary>
        ///<param name="parameter">���ʏ����̃p�����[�^</param>
        ///<retuens>���s�\��true</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        ///<summary>
        ///���s�\���ʏ����̏�Ԃ̕ω��ɂ�蔭��
        ///</summary>
        public event EventHandler CanExecuteChanged;

        ///<summary>
        ///CanExecuteChanged �C�x���g�̔��s
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
        ///�R�}���h���s��̏���
        ///</summary>
        ///<param name="parameter">�R�}���h�̃p���[���[�^���w��</param>
        public void Execute(object parameter)
        {
            this._execute?.Invoke(parameter);
        }

        #endregion  ICommand �̎���
    }
}

/*�����|�C���g 3.4�FSystem.Diagnostics.Debug �N���X�Ńf�o�b�O�R�[�h�������悤�ɂ��悤
 * System.Console �N���X�� WriteLine() ���\�b�h�ł����l�ɏo�̓E�B���h�E�Ƀ��b�Z�[�W���o�͂����邱�Ƃł��邪�A
 * Release ���[�h�ł��ǂ����Ƀ��b�Z�[�W���o�͂���邱�ƂɂȂ�B
 * �R�[�h��� "System.Diagnostics.Debug.WriteLine" �ƋL�q������A"Debug" �̕�����
 * �L�[�{�[�h�J�[�\����u���Ă��� F12 �L�[�������� Debug �N���X�̒�`��`�����Ƃ��ł���B
 * �J��������͂��ׂăA�E�g���C�������Ă���̂ŁA��+ ���N���b�N����
 * �A�E�g���C�����J���Ɗe���\�b�h�̊T�v�Ȃǂ̃R�����g��������悤�ɂȂ�B
 * ���̒��ŁA���\�b�h�̒�`�̐^��̍s�ɕK�� "[Conditional("DEBUG")]" ���t���Ă��邱�Ƃ��m�F�ł���B
 */

/* INotifyPropertyChanged �C���^�[�t�F�[�X�� PropertyChanged �C�x���g�����C���^�[�t�F�[�X�ł���B
 * �v���p�e�B�l�ɕύX���������^�C�~���O�Ŕ��s���邱�ƂŁA�v���p�e�B�ύX�� UI ���֒ʒm���邱�Ƃ��ł���B
 * ���̂��߁A�C�x���g���s�������Ȃ� RaisePropertyChanged() ���\�b�h���`���A
 * �e�v���p�e�B�l���ύX���ꂽ�^�C�~���O�ł��̃��\�b�h���Ăяo���B
 */

/* �����|�C���g 3.5�F#region �` #endregion �ŃA�E�g���C���@�\���g�����Ȃ�
 * Visual Studio �� C# �R�[�f�B���O������Ƃ��A#region �` #endregion �Ŋ���ƁA
 * �������R�[�h��܂��ނ��Ƃ��ł���悤�ɂȂ�B
 * �܂��AVisual Stuido �ɂ͊g���@�\��ǉ����邱�Ƃ��ł��邪�A
 * �uC# outline 2013�v�Ƃ����g���@�\��ǉ�����ƁA
 * ���ׂĂ� "{" �` "}" �ň͂܂ꂽ�������A�E�g���C���������B
 * �g���@�\�́u�c�[���v���u�g���@�\�ƍX�V�v���O�����v���j���[�ŊJ���_�C�A���O�ŁA
 * �c���[���j���[����u�I�����C���v��I�����āuC# outline 2013�v����������Ɛݒ�ł���B
 */

/* �����|�C���g 3.6�F�f�[�^�o�C���f�B���O�̓����^�C�~���O�� UpdateSourceTrigger �ŕύX�ł��� 
 * TextBox �R���g���[���� Text �v���p�e�B�̓����^�C�~���O�̓f�t�H���g�ł̓t�H�[�J�X���������Ƃ��ł���B
 * XAML �Ńf�[�^�o�C���f�B���O�̐ݒ�������Ȃ��Ƃ��A 
 * <TextBox Text="{Binding InputString, UpdateSourceTrigger=PropertyChanged}" /> 
 * �Ƃ���ƁA�e�L�X�g����͂�������ɓ�������邽�߁A
 * �t�H�[�J�X���ړ������Ȃ��Ă��f�[�^�R���e�L�X�g�ɕύX�ʒm�����悤�ɂȂ�B
 * ���ʓI�ɁA�e�L�X�g����͂�������ɕ\�������f�����悤�ɂȂ�B
 */

/* �A���_�[�o�[�́A�v���p�e�B�ϐ��ȂǁA���ڎQ�Ƃ��ė~�����Ȃ��ϐ��ɖڈ�ł����肷��B
 */


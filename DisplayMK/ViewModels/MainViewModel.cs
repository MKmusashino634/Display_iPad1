namespace DisplayiPad1.ViewModels
{
    ///<summary>
    ///MainView �E�B���h�E�ɑ΂���f�[�^�R���e�L�X�g��\��
    ///</summary>
    internal class MainViewModel : NotificationObject
    {
        private string _upperString;
        ///<simmary>
        ///�啶���ɂ���A�ǂݎ���p
        ///</simmary>
        public string UpperString
        {
            get { return this._upperString; }
            private set  { SetProperty(ref  this._upperString, value); }
        }

        private string _inputString;
        ///<summary>
        ///���͕�����̎擾�A�ݒ�Aget��set�����J
        ///</summary>
        public string InputString
        {
            get { return this._inputString; }
            set {
                if (SetProperty(ref this._inputString, value)) 
                {
                    //���͂��ꂽ�������啶���ɕϊ�
                    this.UpperString = this._inputString.ToUpper();

                    //�o�̓E�B���h�E�ɕ\��
                    System.Diagnostics.Debug.WriteLine("�啶��=" + this.UpperString);
                    //Debug�N���X��Release���[�h�ł͓ǂݍ��܂�Ȃ��B
                }
            }
        }

        private DelegateCommand _clearCommand;
        ///<summary>
        ///�N���A�R�}���h�̎擾�Aget�̂�
        ///</summary>
        public DelegateCommand ClearCommand
        {
            get
            {
                /* ?? �͏��������ꏏ�ɂ���
                if (this._clearCommand == null) {
                    this._clearCommand = new DelegateCommand(_ => this.InputString = "");
                }
                return this._clearCommand;
                */

                return this._clearCommand ?? (this._clearCommand = new DelegateCommand(
                    _ => this.InputString = "",
                    _ => !string.IsNullOrEmpty(this.InputString)));
            }
        }
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

/* �����_���F�����̃f���Q�[�g���쐬�A ���؁i�����ڂ��Aexpression tree�j�̍쐬
 * delegate�C���q�̏ȗ����ł���B
 * �Ⴆ�΁A�u  Func<int, bool> predicate = x => { return x < comparedValue; };  �v
 * �i Func<int, bool>�@�Ȃǂ��f���Q�[�g�j
 * ����������Əȗ�����΁A�u  Func<int, bool> predicate = x => x < comparedValue;  �v
 * �������Ȃ��Ȃ�x�̕�����()�ɂ���B
 * 
 * 
 * 
 * �iQiita���j
 * �|�C���g�͊T�v�ɂ�����悤�ɁA�擾���鎮�؂��������鎮�؂�g�ݗ��Ă�Ƃ���ł��B
 * 
 * () => this.Name
 * ��Expression�ł��ꂱ��
 * x => this.Name = x
 * ����ɂ��g�p���̋L�q��Z�����邱�Ƃ��o���܂��B
 * �Ȃ����̃��\�b�h���̂̓v���p�e�B�����łȂ��A�t�B�[���h�⃍�[�J���ϐ��ɑ΂��Ă��g�p�\�ł��B
 * ���؂���f���Q�[�g�𐶐����镔���͏����d���ł��B�p�t�H�[�}���X���l�b�N�ɂȂ�̂ł���΁A
 * �����Ńf���Q�[�g���L���b�V������K�v������܂��B
 * �ihttps://qiita.com/soi/items/043bf216935b8a47820c�j
 * 
 * Control.Invoke(�ł肰�[��)�F�����̃f���Q�[�g�����s
 * Expression<TDelegate>.Compile():���؂ɂ���ċL�q���ꂽ�����_�����R���p�C�����f���Q�[�g�𐶐�
 */
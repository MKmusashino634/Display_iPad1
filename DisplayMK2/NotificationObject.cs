namespace DisplayMK2
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    ///<summary>
    ///]MainView �E�B���h�E�ɑ΂���f�[�^�R���e�L�X�g��\��
    ///</summary>
    internal abstract class NotificationObject : INotifyPropertyChanged
    {
        #region INotifyPropertyCanged �̎���
        ///<summary>
        ///�v���p�e�B�ύX�Ŕ���
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        ///<summary>
        ///PropertyChanged�C�x���g�𔭍s
        ///</summary>
        ///<param name="propertyName">�v���p�e�B�l�ɕύX���������v���p�e�B�����w�肷��</param>
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ///<summary>
        ///<typeparam name="T">�v���p�e�B�̌^</typeparam>
        ///<param name="target="">�ύX����v���p�e�B�̎��̂�ref�w�肷��</param>s
        ///<param name="value"">�ύX��̒l�̎w��</param>
        ///<param name="propertyName"">�v���p�e�B���̎w��</param>
        ///<returns>�ύX����Ȃ�true�Abool�^�͏����ɂ��^�U��Ԃ��^</returns>
        ///���\�b�h�Ɉ�����n�����@�ɁA�l�n���ƎQ�Ɠn��������B
        ///</summary>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(target, value)) return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        #endregion INotifyPropertyCanged �̎���
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


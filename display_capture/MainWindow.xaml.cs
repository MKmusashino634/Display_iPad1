using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using DIMG = System.Drawing.Imaging;
using DRW = System.Drawing;
using MIMG = System.Windows.Media.Imaging;

namespace ScreenShot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// キャプチャ時、自ウィンドウを隠すための待ち時間
        /// </summary>
        private static readonly int CaptureWaitMSec = 300;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr objectHandle);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// キャプチャボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureImage.Source = null;
            // ウィンドウ最小化
            WindowState = WindowState.Minimized;
            // ウィンドウが最小化するまで少し待つ
            await Task.Delay(CaptureWaitMSec);
            // キャプチャ
            CaptureImage.Source = GetFullScreenImage();
            // ウィンドウを元に戻す
            WindowState = WindowState.Normal;
        }

        /// <summary>
        /// 保存ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CaptureImage.Source == null)
            {
                MessageBox.Show("まずキャプチャしてください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 画像保存
            SaveImage();
            // 保存通知
            await NotifySaveImage();
        }

        /// <summary>
        /// キャプチャして保存ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CaptureAndSaveButton_Click(object sender, RoutedEventArgs e)
        {
            // ウィンドウ最小化
            WindowState = WindowState.Minimized;
            // ウィンドウが最小化するまで少し待つ
            await Task.Delay(CaptureWaitMSec);
            // キャプチャ
            CaptureImage.Source = GetFullScreenImage();
            // 画像保存
            SaveImage();
            // ウィンドウを元に戻す
            WindowState = WindowState.Normal;
            // 保存通知
            await NotifySaveImage();
        }

        /// <summary>
        /// 画面全体のイメージ取得
        /// </summary>
        /// <returns></returns>
        private MIMG.BitmapSource GetFullScreenImage()
        {
            int w = (int)SystemParameters.PrimaryScreenWidth;
            int h = (int)SystemParameters.PrimaryScreenHeight;

            using (var bmp = new DRW.Bitmap(w, h, DIMG.PixelFormat.Format32bppRgb))
            using (var grph = DRW.Graphics.FromImage(bmp))
            {
                // スクリーンイメージをコピー
                grph.CopyFromScreen(
                    sourceX: 0, sourceY: 0,
                    destinationX: 0, destinationY: 0,
                    bmp.Size);

                IntPtr bmpHandle = bmp.GetHbitmap();

                try
                {
                    return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bmpHandle,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        MIMG.BitmapSizeOptions.FromEmptyOptions());
                }
                finally
                {
                    DeleteObject(bmpHandle);
                }
            }
        }

        /// <summary>
        /// 画像ファイルを保存
        /// </summary>
        private void SaveImage()
        {
            // ピクチャフォルダのスクリーンショットフォルダ
            string saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Screenshots");
            string saveFilePath = Path.Combine(saveFolder, $"スクショ{DateTime.Now:yyyyMMdd-HHmmss}.jpeg");

            if (!Directory.Exists(saveFolder))
            {
                // 保存先フォルダが無ければ作成
                Directory.CreateDirectory(saveFolder);
            }

            // 画像ファイル保存
            using (Stream stream = new FileStream(saveFilePath, FileMode.Create))
            {
                var encoder = new MIMG.JpegBitmapEncoder();
                encoder.Frames.Add(MIMG.BitmapFrame.Create((MIMG.BitmapSource)CaptureImage.Source));
                encoder.Save(stream);
            }
        }

        /// <summary>
        /// 保存通知
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 画像保存メッセージを表示し、画面の画像をクリアする。
        /// </remarks>
        private async Task NotifySaveImage()
        {
            // 保存通知
            SaveInfo.Visibility = Visibility.Visible;
            await Task.Delay(250);
            // 画像クリア
            CaptureImage.Source = null;
            await Task.Delay(250);
            // 保存通知隠す
            SaveInfo.Visibility = Visibility.Collapsed;
        }

    }
}
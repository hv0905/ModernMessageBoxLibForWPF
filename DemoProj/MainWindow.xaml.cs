using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using ModernMessageBoxLib;
using MessageBox = System.Windows.MessageBox;

namespace DemoProj
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            QModernMessageBox.MainLang = new QMetroMessageLang() {
                Ok = "确定",
                Cancel = "取消",
                Abort = "中止(A)",
                Ignore = "忽略(I)",
                No = "否(N)",
                Yes = "是(Y)",
                Retry = "重试(R)"
            };
            // QModernMessageBox.GlobalBackground = new SolidColorBrush(Colors.White){Opacity = 0.6};
            // QModernMessageBox.GlobalForeground = Brushes.Black;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = new ModernMessageBox("The quick brown fox jumps over the lazy dog.\n", "hello world", ModernMessageboxIcons.Info, "CSharp", "Java",
                "Python") {
                Button1Key = Key.D1,
                Button2Key = Key.D2,
                Button3Key = Key.D3,
                CheckboxText = "Don't show this again",
                CheckboxVisibility = Visibility.Visible,
                TextBoxText = "fsdfdsfsd",
                TextBoxVisibility = Visibility.Visible,
            };
            
            msg.ShowDialog();
            QModernMessageBox.None(msg.TextBoxText,"TextBoxText");
            QModernMessageBox.None(msg.CheckboxChecked.ToString(),"CheckboxChecked");

        }

        private void ButtonBase_OnClick_1(object sender, RoutedEventArgs e)
        {
            QModernMessageBox.Show("The quick brown fox jumps over the lazy dog.", "hello world", QModernMessageBox.QModernMessageBoxButtons.YesNoCancel,
                ModernMessageboxIcons.Error);
        }

        private void ButtonBase_OnClick_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("fdsfdsfsdf", "dfdsfsdfsd", MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Error);
        }

        private async void ButtonBase_OnClick_3(object sender, RoutedEventArgs e)
        {
            var win = new IndeterminateProgressWindow("Please wait while we are installing the virus into your computer. . .");
            win.Show();
            //Do Some Staff
            await Task.Delay(5000);
            //Change the message the 2nd time
            win.Message = "Done!!!";
            win.Close();

        }
    }
}

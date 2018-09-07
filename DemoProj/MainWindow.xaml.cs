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
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = new ModernMessageBox("The quick brown fox jumps over the lazy dog.\n", "hello world", ModernMessageboxIcons.Info, "CSharp", "Java",
                "Python") {
                Button1Key = Key.D1,
                Button2Key = Key.D2,
                Button3Key = Key.D3,
                CheckboxText = "Don't show this again",
                CheckboxVisibility = Visibility.Visible
            };
            
            msg.ShowDialog();
            
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
    }
}

using System.Windows;
using System.Windows.Forms;
using MetroMessageBoxLib;
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
            var msg = new MetroMessageBox("hello the world\n","hello world",MetroMessageboxIcons.Info,"ok","ok","ok");
            msg.ShowDialog();
        }

        private void ButtonBase_OnClick_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The quick brown fox jumps over the lazy dog.jvfdlgvdfsjigjdsfoidoffjffffjdhjsdifsdjfosdijfoisdjfoisdjfoisjdssdiidinvcxmnvcmvxcnvjxcnxcvshdjiofjsifdsidsssosisdi", "Hello world", MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning);
        }

        private void ButtonBase_OnClick_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("fdsfdsfsdf", "dfdsfsdfsd", MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Asterisk);
        }
    }
}

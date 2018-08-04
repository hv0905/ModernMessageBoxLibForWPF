using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            var msg = new MetroMessageBox();
            msg.CloseCaptionButtonEnabled = false;
            msg.Message = "The quick brown fox jumps over the lazy dog.";
            msg.Button1Text = "Hello world";
            msg.Title = "Title";
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

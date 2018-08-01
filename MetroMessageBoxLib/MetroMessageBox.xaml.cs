using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MetroMessageBoxLib
{
    /// <summary>
    /// MetroMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MetroMessageBox : Window
    {
        private bool _exitAnimateDone;


        public MetroMessageBox()
        {
            InitializeComponent();
            SystemSounds.Asterisk.Play();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MetroMessageBox_OnClosing(object sender, CancelEventArgs e)
        {
            if (_exitAnimateDone) return;
            e.Cancel = true;
            var sb = (Storyboard)Resources["CloseStory"];
            sb.Begin();
        }

        private void CloseStory_OnCompleted(object sender, EventArgs e)
        {
            _exitAnimateDone = true;
            Close();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

    public enum MetroMessageboxIcons
    {
        /// <summary>
        /// (i)
        /// </summary>
        Info,
        /// <summary>
        /// (?)
        /// </summary>
        Question,
        /// <summary>
        /// ⚠
        /// </summary>
        Warning,
        /// <summary>
        /// (X)
        /// </summary>
        Error,
        /// <summary>
        /// (√)
        /// </summary>
        Done,
        /// <summary>
        /// 无图标
        /// No any icons
        /// </summary>
        None,
    }


    public enum MetroMessageboxResult
    {
        /// <summary>
        /// 从左往右数第一个按钮(是,确定,...)
        /// The first button in the window from left to right (yes,ok,...)
        /// </summary>
        button1,
        /// <summary>
        /// 从左往右数第二个按钮(否,取消,...)
        /// The second button in the window from left to right (no,cancel,...)
        /// </summary>
        button2,
        /// <summary>
        /// 从左往右数第三个按钮(取消,...)
        /// The third button in the window from left to right (cancel,...)
        /// </summary>
        button3,
        /// <summary>
        /// 右上角关闭按钮
        /// the "Close" button on the right top side
        /// </summary>
        closeCaptionButton,
        /// <summary>
        /// 未知(可能是Alt+F4关闭窗口等)
        /// Unknown(Maybe the user close the window by clicking Alt+F4)
        /// </summary>
        Unknown,
    }

    
}

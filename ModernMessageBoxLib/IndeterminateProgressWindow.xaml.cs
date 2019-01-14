using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Windows.Media;

namespace ModernMessageBoxLib
{
    /// <summary>
    /// A window to notice user the progress.
    /// </summary>
    public partial class IndeterminateProgressWindow
    {
        /// <summary>
        /// Get or set the default background of IndeterminateProgressWindow.
        /// Transparent is allowed.
        /// </summary>
        public static Brush GlobalBackground { get; set; } = new SolidColorBrush(Colors.Black) { Opacity = 0.6 };
        /// <summary>
        /// Get or set the default foreground of IndeterminateProgressWindow
        /// </summary>
        public static Brush GlobalForeground { get; set; } = Brushes.White;
        /// <summary>
        /// Get or set the element to show at the IndeterminateProgressWindow.
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message",
            typeof(object), typeof(IndeterminateProgressWindow), new PropertyMetadata(default(object)));
        /// <summary>
        /// Get or set the CornerRadius of the background border.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IndeterminateProgressWindow), new PropertyMetadata(new CornerRadius(5)));

        /// <summary>
        /// Get or set the element to show at the IndeterminateProgressWindow.
        /// </summary>
        public object Message
        {
            get => GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Get or set the CornerRadius of the background border.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        private bool _sbComplete;

        /// <summary>
        /// Create an object of IndeterminateProgressWindow.
        /// </summary>
        public IndeterminateProgressWindow()
        {
            InitializeComponent();
            Background = GlobalBackground;
            Foreground = GlobalForeground;
        }

        /// <summary>
        /// Create and init an object of IndeterminateProgressWindow.
        /// </summary>
        /// <param name="message">the element to show at the IndeterminateProgressWindow</param>
        public IndeterminateProgressWindow(object message)
        {
            InitializeComponent();
            Background = GlobalBackground;
            Foreground = GlobalForeground;
            Message = message;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!_sbComplete) {
                e.Cancel = true;
                var sb = Resources["CloseStory"] as Storyboard;
                // ReSharper disable once PossibleNullReferenceException
                sb.Begin();
            }
            else {
                e.Cancel = false;
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            _sbComplete = true;
            Close();
        }
    }
}

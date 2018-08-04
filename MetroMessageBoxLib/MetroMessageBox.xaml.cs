using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace MetroMessageBoxLib
{
    /// <summary>
    /// MetroMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MetroMessageBox : Window
    {
        private bool _exitAnimateDone;

        public MetroMessageboxResult Result { get; private set; } = MetroMessageboxResult.Unknown;

        #region DependencyProperty

        public static readonly DependencyProperty Button1TextProperty = DependencyProperty.Register("Button1Text",
            typeof(string), typeof(MetroMessageBox), new PropertyMetadata("Button1"));

        public string Button1Text
        {
            get => (string)GetValue(Button1TextProperty);
            set => SetValue(Button1TextProperty, value);
        }

        public static readonly DependencyProperty Button1StatusProperty = DependencyProperty.Register("Button1Status",
            typeof(MetroMessageboxButtonStatus), typeof(MetroMessageBox),
            new PropertyMetadata(MetroMessageboxButtonStatus.Normal));

        public MetroMessageboxButtonStatus Button1Status
        {
            get => (MetroMessageboxButtonStatus)GetValue(Button1StatusProperty);
            set => SetValue(Button1StatusProperty, value);
        }

        public static readonly DependencyProperty Button2TextProperty = DependencyProperty.Register("Button2Text",
            typeof(string), typeof(MetroMessageBox), new PropertyMetadata("Button2"));

        public string Button2Text
        {
            get => (string)GetValue(Button2TextProperty);
            set => SetValue(Button2TextProperty, value);
        }

        public static readonly DependencyProperty Button2StatusProperty = DependencyProperty.Register("Button2Status",
            typeof(MetroMessageboxButtonStatus), typeof(MetroMessageBox),
            new PropertyMetadata(MetroMessageboxButtonStatus.Invisibled));

        public MetroMessageboxButtonStatus Button2Status
        {
            get => (MetroMessageboxButtonStatus)GetValue(Button2StatusProperty);
            set => SetValue(Button2StatusProperty, value);
        }

        public static readonly DependencyProperty Button3TextProperty = DependencyProperty.Register("Button3Text",
            typeof(string), typeof(MetroMessageBox), new PropertyMetadata("Button3"));

        public string Button3Text
        {
            get => (string)GetValue(Button3TextProperty);
            set => SetValue(Button3TextProperty, value);
        }

        public static readonly DependencyProperty Button3StatusProperty = DependencyProperty.Register("Button3Status",
            typeof(MetroMessageboxButtonStatus), typeof(MetroMessageBox),
            new PropertyMetadata(MetroMessageboxButtonStatus.Invisibled));

        public MetroMessageboxButtonStatus Button3Status
        {
            get => (MetroMessageboxButtonStatus)GetValue(Button3StatusProperty);
            set => SetValue(Button3StatusProperty, value);
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message",
            typeof(string), typeof(MetroMessageBox), new PropertyMetadata(string.Empty));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty HeadIconProperty = DependencyProperty.Register("HeadIcon",
            typeof(MetroMessageboxIcons), typeof(MetroMessageBox), new PropertyMetadata(MetroMessageboxIcons.None,
                (sender, e) => {
                    var current = (MetroMessageBox)sender;
                    var newVal = (MetroMessageboxIcons)e.NewValue;
                    if ((MetroMessageboxIcons)e.OldValue == MetroMessageboxIcons.None &&
                        newVal != MetroMessageboxIcons.None) {
                        current.img_headIcon.Visibility = Visibility.Visible;
                        current.iconPlace.Width = new GridLength(70);
                    }

                    switch (newVal) {
                        case MetroMessageboxIcons.Info:
                            current.img_headIcon.Source = current.Resources["info"] as BitmapImage;
                            break;
                        case MetroMessageboxIcons.Question:
                            current.img_headIcon.Source = current.Resources["question"] as BitmapImage;
                            break;
                        case MetroMessageboxIcons.Warning:
                            current.img_headIcon.Source = current.Resources["warning"] as BitmapImage;
                            break;
                        case MetroMessageboxIcons.Error:
                            current.img_headIcon.Source = current.Resources["error"] as BitmapImage;
                            break;
                        case MetroMessageboxIcons.Done:
                            current.img_headIcon.Source = current.Resources["done"] as BitmapImage;
                            break;
                        case MetroMessageboxIcons.None:
                            current.img_headIcon.Visibility = Visibility.Collapsed;
                            current.iconPlace.Width = new GridLength(0);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }));

        public MetroMessageboxIcons HeadIcon
        {
            get => (MetroMessageboxIcons)GetValue(HeadIconProperty);
            set => SetValue(HeadIconProperty, value);
        }


        public static readonly DependencyProperty CloseCaptionButtonEnabledProperty =
            DependencyProperty.Register("CloseCaptionButtonEnabled", typeof(bool), typeof(MetroMessageBox),
                new PropertyMetadata(true));

        public bool CloseCaptionButtonEnabled
        {
            get => (bool)GetValue(CloseCaptionButtonEnabledProperty);
            set => SetValue(CloseCaptionButtonEnabledProperty, value);
        }

        #endregion

        public MetroMessageBox()
        {
            InitializeComponent();
            SystemSounds.Asterisk.Play();
        }

        #region Events

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Result = MetroMessageboxResult.CloseCaptionButton;
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

        private void MetroMessageBox_OnStateChanged(object sender, EventArgs e)
        {
            if (WindowState != WindowState.Normal)
                WindowState = WindowState.Normal;
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            // ReSharper disable PossibleUnintendedReferenceComparison
            if (sender == rbtn1)
                Result = MetroMessageboxResult.Button1;
            else if (sender == rbtn2)
                Result = MetroMessageboxResult.Button2;
            else Result = MetroMessageboxResult.Button3;
            // ReSharper restore PossibleUnintendedReferenceComparison
            Close();
        }

        #endregion
    }
}

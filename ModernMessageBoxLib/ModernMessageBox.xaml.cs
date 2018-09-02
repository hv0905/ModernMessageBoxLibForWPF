using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using ModernMessageBoxLib.Helper;
using static System.Byte;

namespace ModernMessageBoxLib
{
    /// <summary>
    /// Display a MessageBox with a Modern Style
    /// </summary>
    public partial class ModernMessageBox : Window
    {
        public ModernMessageboxResult Result { get; private set; } = ModernMessageboxResult.Unknown;

        #region DependencyProperty

        public static readonly DependencyProperty Button1TextProperty = DependencyProperty.Register("Button1Text",
            typeof(string), typeof(ModernMessageBox), new PropertyMetadata("Button1"));

        /// <summary>
        /// The display content of Button1
        /// </summary>
        public string Button1Text
        {
            get => (string)GetValue(Button1TextProperty);
            set => SetValue(Button1TextProperty, value);
        }

        public static readonly DependencyProperty Button1StatusProperty = DependencyProperty.Register("Button1Status",
            typeof(ModernMessageboxButtonStatus), typeof(ModernMessageBox),
            new PropertyMetadata(ModernMessageboxButtonStatus.Normal));

        /// <summary>
        /// The status of Button1(IsEnabled and Visibility)
        /// </summary>
        public ModernMessageboxButtonStatus Button1Status
        {
            get => (ModernMessageboxButtonStatus)GetValue(Button1StatusProperty);
            set => SetValue(Button1StatusProperty, value);
        }

        public static readonly DependencyProperty Button2TextProperty = DependencyProperty.Register("Button2Text",
            typeof(string), typeof(ModernMessageBox), new PropertyMetadata("Button2"));

        /// <summary>
        /// The display content of Button2
        /// </summary>
        public string Button2Text
        {
            get => (string)GetValue(Button2TextProperty);
            set => SetValue(Button2TextProperty, value);
        }

        public static readonly DependencyProperty Button2StatusProperty = DependencyProperty.Register("Button2Status",
            typeof(ModernMessageboxButtonStatus), typeof(ModernMessageBox),
            new PropertyMetadata(ModernMessageboxButtonStatus.Invisibled));

        /// <summary>
        /// The status of Button2(IsEnabled and Visibility)
        /// </summary>
        public ModernMessageboxButtonStatus Button2Status
        {
            get => (ModernMessageboxButtonStatus)GetValue(Button2StatusProperty);
            set => SetValue(Button2StatusProperty, value);
        }

        public static readonly DependencyProperty Button3TextProperty = DependencyProperty.Register("Button3Text",
            typeof(string), typeof(ModernMessageBox), new PropertyMetadata("Button3"));

        /// <summary>
        /// The display content of Button3
        /// </summary>
        public string Button3Text
        {
            get => (string)GetValue(Button3TextProperty);
            set => SetValue(Button3TextProperty, value);
        }

        public static readonly DependencyProperty Button3StatusProperty = DependencyProperty.Register("Button3Status",
            typeof(ModernMessageboxButtonStatus), typeof(ModernMessageBox),
            new PropertyMetadata(ModernMessageboxButtonStatus.Invisibled));

        /// <summary>
        /// The status of Button3(IsEnabled and Visibility)
        /// </summary>
        public ModernMessageboxButtonStatus Button3Status
        {
            get => (ModernMessageboxButtonStatus)GetValue(Button3StatusProperty);
            set => SetValue(Button3StatusProperty, value);
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message",
            typeof(string), typeof(ModernMessageBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The message to display in the messagebox
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty HeadIconProperty = DependencyProperty.Register("HeadIcon",
            typeof(ModernMessageboxIcons), typeof(ModernMessageBox), new PropertyMetadata(ModernMessageboxIcons.None,
                (sender, e) => {
                    var current = (ModernMessageBox)sender;
                    var newVal = (ModernMessageboxIcons)e.NewValue;
                    if ((ModernMessageboxIcons)e.OldValue == ModernMessageboxIcons.None &&
                        newVal != ModernMessageboxIcons.None) {
                        current.img_HeadIcon.Visibility = Visibility.Visible;
                        current.iconPlace.Width = new GridLength(70);
                    }

                    switch (newVal) {
                        case ModernMessageboxIcons.Info:
                            current.img_HeadPath.Data = current.Resources["icoInfo"] as Geometry;
                            break;
                        case ModernMessageboxIcons.Question:
                            current.img_HeadPath.Data = current.Resources["icoHelp"] as Geometry;
                            break;
                        case ModernMessageboxIcons.Warning:
                            current.img_HeadPath.Data = current.Resources["icoWarning"] as Geometry;
                            break;
                        case ModernMessageboxIcons.Error:
                            current.img_HeadPath.Data = current.Resources["icoError"] as Geometry;
                            break;
                        case ModernMessageboxIcons.Done:
                            current.img_HeadPath.Data = current.Resources["icoCheck"] as Geometry;
                            break;
                        case ModernMessageboxIcons.None:
                            current.img_HeadIcon.Visibility = Visibility.Collapsed;
                            current.iconPlace.Width = new GridLength(0);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }));

        /// <summary>
        /// Messagebox's icon
        /// </summary>
        public ModernMessageboxIcons HeadIcon
        {
            get => (ModernMessageboxIcons)GetValue(HeadIconProperty);
            set => SetValue(HeadIconProperty, value);
        }


        public static readonly DependencyProperty CloseCaptionButtonEnabledProperty =
            DependencyProperty.Register("CloseCaptionButtonEnabled", typeof(bool), typeof(ModernMessageBox),
                new PropertyMetadata(true));

        /// <summary>
        /// control the IsEnabled attr of the close button
        /// </summary>
        public bool CloseCaptionButtonEnabled
        {
            get => (bool)GetValue(CloseCaptionButtonEnabledProperty);
            set => SetValue(CloseCaptionButtonEnabledProperty, value);
        }

        public static readonly DependencyProperty CheckboxVisibilityProperty =
            DependencyProperty.Register("CheckboxVisibility", typeof(Visibility), typeof(ModernMessageBox),
                new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// control the Visibility of the checkbox
        /// </summary>
        public Visibility CheckboxVisibility
        {
            get => (Visibility)GetValue(CheckboxVisibilityProperty);
            set => SetValue(CheckboxVisibilityProperty, value);
        }

        public static readonly DependencyProperty CheckboxTextProperty = DependencyProperty.Register("CheckboxText",
            typeof(string), typeof(ModernMessageBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The text to display on the checkbox
        /// </summary>
        public string CheckboxText
        {
            get => (string)GetValue(CheckboxTextProperty);
            set => SetValue(CheckboxTextProperty, value);
        }

        public static readonly DependencyProperty CheckboxCheckedProperty =
            DependencyProperty.Register("CheckboxChecked", typeof(bool), typeof(ModernMessageBox),
                new PropertyMetadata(false));

        /// <summary>
        /// Get or set the IsChecked attr of the checkbox
        /// </summary>
        public bool? CheckboxChecked
        {
            get => (bool)GetValue(CheckboxCheckedProperty);
            set => SetValue(CheckboxCheckedProperty, value);
        }

        #endregion

        #region prop

        /// <summary>
        /// The key to trigger Button1
        /// </summary>
        public Key? Button1Key { get; set; }

        /// <summary>
        /// /// The key to trigger Button2
        /// </summary>
        public Key? Button2Key { get; set; }

        /// <summary>
        /// The key to trigger Button3
        /// </summary>
        public Key? Button3Key { get; set; }

        /// <summary>
        /// The key to trigger closecaptionbutton
        /// Default is Escape
        /// </summary>
        public Key? CloseCaptionButtonKey { get; set; } = Key.Escape;

        #endregion

        /// <summary>
        /// Create a object of ModernMessageBox
        /// </summary>
        public ModernMessageBox()
        {
            InitializeComponent();
            Background = QModernMessageBox.GlobalBackground;
            Foreground = QModernMessageBox.GlobalForeground;
        }

        /// <summary>
        /// Create and init ModernMessageBox
        /// </summary>
        public ModernMessageBox(string message, string title, ModernMessageboxIcons headIcon = ModernMessageboxIcons.None,
                               string button1Text = null, string button2Text = null, string button3Text = null)
        {
            InitializeComponent();
            Background = QModernMessageBox.GlobalBackground;
            Foreground = QModernMessageBox.GlobalForeground;
            Message = message;
            Title = title;
            HeadIcon = headIcon;
            if (button1Text != null) {
                Button1Text = button1Text;
            }

            if (button2Text != null) {
                Button2Text = button2Text;
                Button2Status = ModernMessageboxButtonStatus.Normal;
            }

            // ReSharper disable once InvertIf
            if (button3Text != null) {
                Button3Text = button3Text;
                Button3Status = ModernMessageboxButtonStatus.Normal;
            }
        }

        #region Events

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Result = ModernMessageboxResult.CloseCaptionButton;
            Close();
        }

        private void MetroMessageBox_OnClosing(object sender, CancelEventArgs e)
        {
//            if (_exitAnimateDone) return;
//            e.Cancel = true;
//            var sb = (Storyboard)Resources["CloseStory"];
//            sb.Begin();
        }

//        private void CloseStory_OnCompleted(object sender, EventArgs e)
//        {
//            _exitAnimateDone = true;
//            Close();
//        }

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
                Result = ModernMessageboxResult.Button1;
            else if (sender == rbtn2)
                Result = ModernMessageboxResult.Button2;
            else Result = ModernMessageboxResult.Button3;
            // ReSharper restore PossibleUnintendedReferenceComparison
            Close();
        }

        private void MetroMessageBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Button1Key && Button1Status == ModernMessageboxButtonStatus.Normal) {
                ResultButton_Click(rbtn1, null);
            }
            else if (e.Key == Button2Key && Button2Status == ModernMessageboxButtonStatus.Normal) {
                ResultButton_Click(rbtn2, null);
            }
            else if (e.Key == Button3Key && Button3Status==ModernMessageboxButtonStatus.Normal) {
                ResultButton_Click(rbtn3, null);
            }
            else if (e.Key == CloseCaptionButtonKey && CloseCaptionButtonEnabled) {
                ButtonBase_OnClick(null, null);
            }
        }

        #endregion

        private void ModernMessageBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!WindowBlurBackgroundHelper.BlurWindow(this)) {
                if (this.Background is SolidColorBrush scb) {
                    var col = scb.Color;
                    col.A = MaxValue;
                    Background = new SolidColorBrush(col);

                }
            }

            switch (HeadIcon) {
                case ModernMessageboxIcons.Info:
                    SystemSounds.Asterisk.Play();
                    break;
                case ModernMessageboxIcons.Question:
                    SystemSounds.Question.Play();
                    break;
                case ModernMessageboxIcons.Warning:
                    SystemSounds.Exclamation.Play();
                    break;
                case ModernMessageboxIcons.Error:
                    SystemSounds.Hand.Play();
                    break;
                case ModernMessageboxIcons.Done:
                    SystemSounds.Asterisk.Play();
                    break;
            }
        }
    }
}

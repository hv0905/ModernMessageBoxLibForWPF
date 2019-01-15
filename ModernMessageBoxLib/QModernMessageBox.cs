using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ModernMessageBoxLib
{
    /// <summary>
    /// Common usage of ModernMessageBox,
    /// Just like using <see cref="MessageBox"/> in WPF or using QMessageBox in QT
    /// </summary>
    public static class QModernMessageBox
    {
        /// <summary>
        /// Get or set the default owner of the MessageBoxWindow
        /// </summary>
        public static Window GlobalParentWindow { get; set; }

        /// <summary>
        /// Get or set the text of the buttons
        /// The default value is in English. If you want other language, you should specify them manully
        /// </summary>
        public static QMetroMessageLang MainLang { get; set; } = new QMetroMessageLang();

        /// <summary>
        /// Specify the default Background for ModernMessageBox
        /// You can specify a transparent or half-transparent value in this field.
        /// If the operate system is Win10, The window will get a Blur background.
        /// The default value is Black,0.6 Opacity
        /// </summary>
        public static Brush GlobalBackground { get; set; } = new SolidColorBrush(Colors.Black) {Opacity = 0.6};
        /// <summary>
        /// Specify the default Foreground for ModernMessageBox
        /// The default value is White
        /// </summary>
        public static Brush GlobalForeground { get; set; } = Brushes.White;

        /// <summary>
        /// Specify if the window will get a blur background in win10.
        /// To enable this feature, pls make sure your Background prop is not solid.
        /// Set this value to false if u don't need this feature.
        /// The default value is true.
        /// </summary>
        public static bool GlobalEnableWindowBlur { get; set; } = true;

        /// <summary>
        /// Create and show a Modern Messagebox
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        /// <param name="btns">
        /// The bottons to show
        /// </param>
        /// <param name="icon">
        /// The icon to show
        /// </param>
        /// <param name="playSound">play the system sound when the messageBox show</param>
        public static ModernMessageboxResult Show(Window parentWindow, string msg, string title,
                                                  QModernMessageBoxButtons btns,
                                                  ModernMessageboxIcons icon = ModernMessageboxIcons.None,
                                                  bool playSound = true)
        {
            var msgBox = new ModernMessageBox(msg, title, icon) {
                Background = GlobalBackground,
                Foreground = GlobalForeground,
                Owner = parentWindow,
            };
            switch (btns) {
                case QModernMessageBoxButtons.Ok:
                    msgBox.Button1Text = MainLang.Ok;
                    msgBox.Button1Key = Key.Enter;
                    break;
                case QModernMessageBoxButtons.OkCancel:
                    msgBox.Button1Text = MainLang.Ok;
                    msgBox.Button1Key = Key.Enter;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = MainLang.Cancel;
                    msgBox.Button2Key = Key.Escape;
                    break;
                case QModernMessageBoxButtons.YesNo:
                    msgBox.Button1Text = MainLang.Yes;
                    msgBox.Button1Key = Key.Y;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = MainLang.No;
                    msgBox.Button2Key = Key.N;
                    msgBox.CloseCaptionButtonEnabled = false;
                    break;
                case QModernMessageBoxButtons.YesNoCancel:
                    msgBox.Button1Text = MainLang.Yes;
                    msgBox.Button1Key = Key.Y;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = MainLang.No;
                    msgBox.Button2Key = Key.N;
                    msgBox.Button3Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button3Text = MainLang.Cancel;
                    msgBox.Button3Key = Key.Escape;
                    break;
                case QModernMessageBoxButtons.AbortRetryIgnore:
                    msgBox.Button1Text = MainLang.Abort;
                    msgBox.Button1Key = Key.A;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = MainLang.Retry;
                    msgBox.Button2Key = Key.R;
                    msgBox.Button3Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button3Text = MainLang.Ignore;
                    msgBox.Button3Key = Key.I;
                    msgBox.CloseCaptionButtonEnabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(btns), btns, null);
            }

            msgBox.ShowDialog();
            return msgBox.Result;
        }

        /// <summary>
        /// Create and show a Modern Messagebox
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        /// <param name="btns">
        /// The bottons to show
        /// </param>
        /// <param name="icon">
        /// The icon to show
        /// </param>
        /// <param name="playSound">play the system sound when the messageBox show</param>
        public static ModernMessageboxResult Show(string msg, string title, QModernMessageBoxButtons btns,
                                                  ModernMessageboxIcons icon = ModernMessageboxIcons.None,
                                                  bool playSound = true) => Show(GlobalParentWindow, msg, title, btns, icon,
            playSound);

        /// <summary>
        /// Create and show a metro messagebox with a warning sign and a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Warning(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Warning);

        /// <summary>
        /// Create and show a metro messagebox with a warning sign and a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Warning(Window parentWindow, string msg, string title) =>
            Show(parentWindow, msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Warning);

        /// <summary>
        /// Create and show a metro messagebox with an infomation sign and a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Info(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Info);

        /// <summary>
        /// Create and show a metro messagebox with an infomation sign and a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Info(Window parentWindow, string msg, string title) =>
            Show(parentWindow, msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Info);

        /// <summary>
        /// Create and show a metro messagebox with an error sign and a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Error(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Error);

        /// <summary>
        /// Create and show a metro messagebox with an error sign and a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Error(Window parentWindow,string msg, string title) =>
            Show(parentWindow,msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Error);

        /// <summary>
        /// Create and show a metro messagebox with a question sign and a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Question(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Question);

        /// <summary>
        /// Create and show a metro messagebox with a question sign and a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Question(Window parentWindow, string msg, string title) =>
            Show(parentWindow, msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Question);

        /// <summary>
        /// Create and show a metro messagebox with a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void None(string msg, string title) => Show(msg, title, QModernMessageBoxButtons.Ok);

        /// <summary>
        /// Create and show a metro messagebox with a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void None(Window parentWindow, string msg, string title) =>
            Show(parentWindow, msg, title, QModernMessageBoxButtons.Ok);

        /// <summary>
        /// Create and show a metro messagebox with a done sign and a "OK" button
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Done(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Done);

        /// <summary>
        /// Create and show a metro messagebox with a done sign and a "OK" button
        /// </summary>
        /// <param name="parentWindow">the owner of the messagebox window</param>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Done(Window parentWindow, string msg, string title) =>
            Show(parentWindow, msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Done);

        /// <summary>
        /// Define the buttons on the QModernMessageBox
        /// </summary>
        public enum QModernMessageBoxButtons
        {
            /// <summary>
            /// Button1:OK
            /// </summary>
            Ok,
            /// <summary>
            /// Button1:OK
            /// Button2:Cancel
            /// </summary>
            OkCancel,
            /// <summary>
            /// Button1:Yes
            /// Button2:No
            /// </summary>
            YesNo,
            /// <summary>
            /// Button1:Yes
            /// Button2:No
            /// Button3:Cancel
            /// </summary>
            YesNoCancel,
            /// <summary>
            /// Button1:Abort
            /// Button2:Retry
            /// Button3:Ignore
            /// </summary>
            AbortRetryIgnore,
        }
    }

    /// <summary>
    /// Provide language setting for QMessageBox
    /// the default language is in English
    /// </summary>
    public class QMetroMessageLang
    {
        /// <summary>
        /// get or set the display of the OK button
        /// </summary>
        public string Ok { get; set; } = "OK";
        /// <summary>
        /// get or set the display of the Cancel button
        /// </summary>
        public string Cancel { get; set; } = "Cancel";
        /// <summary>
        /// get or set the display of the Yes button
        /// </summary>
        public string Yes { get; set; } = "Yes";
        /// <summary>
        /// get or set the display of the No button
        /// </summary>
        public string No { get; set; } = "No";
        /// <summary>
        /// get or set the display of the Ignore button
        /// </summary>
        public string Ignore { get; set; } = "Ignore";
        /// <summary>
        /// get or set the display of the Retry button
        /// </summary>
        public string Retry { get; set; } = "Retry";
        /// <summary>
        /// get or set the display of the Abort button
        /// </summary>
        public string Abort { get; set; } = "Abort";
    }
}

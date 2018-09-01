using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ModernMessageBoxLib.Properties;

namespace ModernMessageBoxLib
{
    /// <summary>
    /// 对MetroMessageBox的常用实现,
    /// 使用方法类似于WPF的MessageBox.
    /// Common usage of ModernMessageBox,
    /// Just like using <see cref="System.Windows.MessageBox"/> in WPF.
    /// </summary>
    public static class QModernMessageBox
    {

        public static QMetroMessageLang MainLang { get; set; } = new QMetroMessageLang();

        /// <summary>
        /// 创建并显示一个信息框
        /// Create and show a Metro Messagebox
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        /// <param name="btns">
        /// The bottons to show
        /// 要显示的按钮
        /// </param>
        /// <param name="icon">
        /// The icon to show
        /// 要显示的图标
        /// </param>
        public static ModernMessageboxResult Show(string msg, string title, QModernMessageBoxButtons btns,
                                                 ModernMessageboxIcons icon = ModernMessageboxIcons.None)
        {
            var msgBox = new ModernMessageBox(msg, title, icon);
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
        /// Create and show a metro messagebox with a warning sign and a "OK" button
        /// 创建并显示一个带有警告标识和"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Warning(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Warning);

        /// <summary>
        /// Create and show a metro messagebox with a infomation sign and a "OK" button
        /// 创建并显示一个带有信息标识和"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Info(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Info);

        /// <summary>
        /// Create and show a metro messagebox with a error sign and a "OK" button
        /// 创建并显示一个带有错误标识和"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Error(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Error);

        /// <summary>
        /// Create and show a metro messagebox with a question sign and a "OK" button
        /// 创建并显示一个带有问号标识和"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Question(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Question);

        /// <summary>
        /// Create and show a metro messagebox with a "OK" button
        /// 创建并显示一个带有"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void None(string msg, string title) => Show(msg, title, QModernMessageBoxButtons.Ok);

        /// <summary>
        /// Create and show a metro messagebox with a done sign and a "OK" button
        /// 创建并显示一个带有对勾标识和"确定"按钮的消息框
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="title">Title</param>
        public static void Done(string msg, string title) =>
            Show(msg, title, QModernMessageBoxButtons.Ok, ModernMessageboxIcons.Done);

        /// <summary>
        /// QMetroMessagebox的按扭组合
        /// </summary>
        public enum QModernMessageBoxButtons
        {
            /// <summary>
            /// 按钮1:确定
            /// Button1:OK
            /// </summary>
            Ok,
            /// <summary>
            /// 按钮1:确定
            /// 按钮2:取消
            /// Button1:OK
            /// Button2:Cancel
            /// </summary>
            OkCancel,
            /// <summary>
            /// 按钮1:是
            /// 按钮2:否
            /// Button1:Yes
            /// Button2:No
            /// </summary>
            YesNo,
            /// <summary>
            /// 按钮1:是
            /// 按钮2:否
            /// 按钮3:取消
            /// Button1:Yes
            /// Button2:No
            /// Button3:Cancel
            /// </summary>
            YesNoCancel,
            /// <summary>
            /// 按钮1:中止
            /// 按钮2:重试
            /// 按钮3:忽略
            /// Button1:Abort
            /// Button2:Retry
            /// Button3:Ignore
            /// </summary>
            AbortRetryIgnore,
        }
    }

    /// <summary>
    /// 用于给QMessageBox提供语言设定
    /// Provide language setting for QMessageBox
    /// </summary>
    public class QMetroMessageLang
    {
        public string Ok { get; set; } = "OK";
        public string Cancel { get; set; } = "Cancel";
        public string Yes { get; set; } = "Yes";
        public string No { get; set; } = "No";
        public string Ignore { get; set; } = "Ignore";
        public string Retry { get; set; } = "Retry";
        public string Abort { get; set; } = "Abort";
    }
}

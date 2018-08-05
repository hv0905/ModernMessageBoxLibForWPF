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
        /// <summary>
        /// 更改信息框的按钮文本,有以下Key可选:
        /// Change the text of the button ,there are those key can be choose:
        /// {ok,cancel,yes,no,abort,retry,ignore}
        /// </summary>
        public static Dictionary<string, string> buttonTextMap = new Dictionary<string, string>();
        private static Dictionary<string, string> _defaultButtonTextMap = new Dictionary<string, string>();


        static QModernMessageBox()
        {
            ChDefaultBtnTxt(CultureInfo.CurrentCulture);
            ReadMap(_defaultButtonTextMap, "en");
        }

        /// <summary>
        /// 将信息框按钮语言更改到指定的语言
        /// Change the messagebox button to the following language
        /// </summary>
        /// <param name="region"></param>
        public static void ChDefaultBtnTxt(CultureInfo region)
        {
            ChDefaultBtnTxt(region.Name);
        }

        /// <summary>
        /// 将信息框按钮语言更改到指定的语言
        /// Change the messagebox button to the following language
        /// </summary>
        /// <param name="region">地区缩写</param>
        public static void ChDefaultBtnTxt(string region)
        {
            var tmp = region.ToLower();
            if (tmp != "zh-cn") {
                tmp = tmp.Substring(0, 2);
            }

            ReadMap(buttonTextMap, tmp);
        }

        private static void ReadMap(Dictionary<string, string> dst, string loc)
        {
            dst.Clear();
            var lens = Resources.QMessageboxBtnText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            lens.RemoveAll(x => !x.StartsWith(loc));

            var kwpair = lens.Select(x => {
                var tmp = x.Split('=');
                var key = tmp[0].Split('.')[1];
                var value = tmp[1];
                return new KeyValuePair<string, string>(key, value);
            });

            foreach (var item in kwpair) {
                dst.Add(item.Key, item.Value);
            }
        }

        private static string GetTxt(string key)
        {
            if (buttonTextMap.ContainsKey(key))
                return buttonTextMap[key];
            else return _defaultButtonTextMap[key];
        }

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
                    msgBox.Button1Text = GetTxt("ok");
                    msgBox.Button1Key = Key.Enter;
                    break;
                case QModernMessageBoxButtons.OkCancel:
                    msgBox.Button1Text = GetTxt("ok");
                    msgBox.Button1Key = Key.Enter;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = GetTxt("cancel");
                    msgBox.Button2Key = Key.Escape;
                    break;
                case QModernMessageBoxButtons.YesNo:
                    msgBox.Button1Text = GetTxt("yes");
                    msgBox.Button1Key = Key.Y;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = GetTxt("no");
                    msgBox.Button2Key = Key.N;
                    msgBox.CloseCaptionButtonEnabled = false;
                    break;
                case QModernMessageBoxButtons.YesNoCancel:
                    msgBox.Button1Text = GetTxt("yes");
                    msgBox.Button1Key = Key.Y;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = GetTxt("no");
                    msgBox.Button2Key = Key.N;
                    msgBox.Button3Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button3Text = GetTxt("cancel");
                    msgBox.Button3Key = Key.Escape;
                    break;
                case QModernMessageBoxButtons.AbortRetryIgnore:
                    msgBox.Button1Text = GetTxt("abort");
                    msgBox.Button1Key = Key.A;
                    msgBox.Button2Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button2Text = GetTxt("retry");
                    msgBox.Button2Key = Key.R;
                    msgBox.Button3Status = ModernMessageboxButtonStatus.Normal;
                    msgBox.Button3Text = GetTxt("ignore");
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace ModernMessageBoxLib.Helper
{
    public static class WindowBlurBackgroundHelper
    {
        /// <summary>
        /// 使用Windows10创意者更新API设置窗口背景为毛玻璃背景
        /// 在win7下本方法不会做出任何更改
        /// </summary>
        /// <returns>是否造成了更改</returns>
        public static bool BlurWindow(Window win)
        {
            if (Environment.OSVersion.Version.Major < 10 && Environment.OSVersion.Version.Minor < 2) {
                return false;
            }

            var winhelp = new WindowInteropHelper(win);
            var accent = new UnSafeWin32NativeMethods.AccentPolicy {
                AccentState = UnSafeWin32NativeMethods.AccentState.AccentEnableBlurbehind
            };
            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new UnSafeWin32NativeMethods.WindowCompositionAttributeData {
                Attribute = UnSafeWin32NativeMethods.WindowCompositionAttribute.WcaAccentPolicy,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            UnSafeWin32NativeMethods.SetWindowCompositionAttribute(winhelp.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
            return true;
        }
    }
}

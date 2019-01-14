using System;
using System.Runtime.InteropServices;

namespace ModernMessageBoxLib.Helper
{

    internal static class UnSafeWin32NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        internal enum AccentState
        {
            AccentDisabled = 1,
            AccentEnableGradient = 0,
            AccentEnableTransparentgradient = 2,
            AccentEnableBlurbehind = 3,
            AccentInvalidState = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            // ReSharper disable FieldCanBeMadeReadOnly.Global
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
            // ReSharper restore FieldCanBeMadeReadOnly.Global
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            // ...
            WcaAccentPolicy = 19
            // ...
        }
    }
}

namespace ModernMessageBoxLib
{
    public enum ModernMessageboxResult
    {
        /// <summary>
        /// 从左往右数第一个按钮(是,确定,...)
        /// The first button in the window from left to right (yes,ok,...)
        /// </summary>
        Button1,
        /// <summary>
        /// 从左往右数第二个按钮(否,取消,...)
        /// The second button in the window from left to right (no,cancel,...)
        /// </summary>
        Button2,
        /// <summary>
        /// 从左往右数第三个按钮(取消,...)
        /// The third button in the window from left to right (cancel,...)
        /// </summary>
        Button3,
        /// <summary>
        /// 右上角关闭按钮
        /// the "Close" button on the right top side
        /// </summary>
        CloseCaptionButton,
        /// <summary>
        /// 窗体未关闭或未知(可能是Alt+F4关闭窗口等)
        /// The window haven't closed or Unknown(Maybe the user closed the window by clicking Alt+F4)
        /// </summary>
        Unknown,
    }
}

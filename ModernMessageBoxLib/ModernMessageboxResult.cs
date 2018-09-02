namespace ModernMessageBoxLib
{
    public enum ModernMessageboxResult
    {
        /// <summary>
        /// The first button in the window from left to right (yes,ok,...)
        /// </summary>
        Button1,
        /// <summary>
        /// The second button in the window from left to right (no,cancel,...)
        /// </summary>
        Button2,
        /// <summary>
        /// The third button in the window from left to right (cancel,...)
        /// </summary>
        Button3,
        /// <summary>
        /// the "Close" button on the right top side
        /// </summary>
        CloseCaptionButton,
        /// <summary>
        /// The window haven't closed or Unknown(Maybe the user closed the window by clicking Alt+F4)
        /// </summary>
        Unknown,
    }
}

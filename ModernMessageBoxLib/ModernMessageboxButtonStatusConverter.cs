using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ModernMessageBoxLib
{
    internal class ModernMessageboxButtonStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tmp = (ModernMessageboxButtonStatus)value;
            if (targetType == typeof(Visibility)) {
                return tmp == ModernMessageboxButtonStatus.Invisibled ? Visibility.Collapsed : Visibility.Visible;
            }

            if (targetType == typeof(bool)) {
                return tmp != ModernMessageboxButtonStatus.Disabled;
            }

            throw new ArgumentException(nameof(targetType));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}

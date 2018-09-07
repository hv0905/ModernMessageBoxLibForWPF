using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ModernMessageBoxLib
{
    internal class ModernMessageboxButtonStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ReSharper disable once PossibleNullReferenceException
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


    internal class ColorOpticityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color col;
            if (value is SolidColorBrush brush) {
                col = brush.Color;
            }else if (value is Color color) {
                col = color;
            }else throw new ArgumentException(nameof(value));

            col.A = byte.MaxValue;

            if (targetType.IsSubclassOf(typeof(Brush)) || targetType == typeof(Brush)) {
                return new SolidColorBrush(col);
            }else if (targetType == typeof(Color)) {
                return col;
            }else throw new ArgumentException(nameof(targetType));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Convert(value, targetType, parameter, culture);
    }
}

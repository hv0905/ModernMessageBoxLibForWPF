using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MetroMessageBoxLib {

    internal class MsgboxBtnsVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility)) {
                throw new ArgumentException(nameof(targetType));
            }

            // ReSharper disable once PossibleNullReferenceException
            var tmp = (MetroMessageboxButtonStatus)value;
            return tmp == MetroMessageboxButtonStatus.Invisibled ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
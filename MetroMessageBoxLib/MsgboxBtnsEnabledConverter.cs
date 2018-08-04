using System;
using System.Globalization;
using System.Windows.Data;

namespace MetroMessageBoxLib {

    internal class MsgboxBtnsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool)) {
                throw new ArgumentException(nameof(targetType));
            }

            // ReSharper disable once PossibleNullReferenceException
            var tmp = (MetroMessageboxButtonStatus)value;
            return tmp != MetroMessageboxButtonStatus.Disabled;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
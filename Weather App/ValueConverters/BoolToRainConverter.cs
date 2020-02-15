using System;
using System.Globalization;
using System.Windows.Data;

namespace Weather.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        private const string TrueCase = "Currently raining";
        private const string FalseCase = "Currently not raining";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool isRaining)) return "";
            
            return isRaining ? TrueCase : FalseCase;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string isRaining)) return false;
            return isRaining == TrueCase;
        }
    }
}

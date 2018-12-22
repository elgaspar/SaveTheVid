using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SaveTheVid.Views.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    class BoolToTypeConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue == true)
                return "Audio";
            return "Video";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

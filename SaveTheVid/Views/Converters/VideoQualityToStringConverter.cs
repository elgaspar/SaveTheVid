using SaveTheVid.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SaveTheVid.Views.Converters
{
    [ValueConversion(typeof(Options.VideoQualities), typeof(string))]
    class VideoQualityToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return EnumeratorHelper.GetDescription((Options.VideoQualities)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace Simpler.Net.Wpf.ValueConverters
{
    /// <summary>
    /// Basically an enum value checker for binding to XAML radio buttons.
    /// From http://stackoverflow.com/a/2908885
    /// </summary>
    public class EnumToBooleanConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}

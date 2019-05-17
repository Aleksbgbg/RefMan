namespace Refman.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    [ValueConversion(typeof(int), typeof(int))]
    internal class AddOneConverter : IValueConverter
    {
        public static AddOneConverter Default { get; } = new AddOneConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
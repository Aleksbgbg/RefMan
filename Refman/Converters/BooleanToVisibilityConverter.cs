namespace Refman.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    [ValueConversion(typeof(bool), typeof(Visibility))]
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        private readonly bool _visibleValue;

        private BooleanToVisibilityConverter(bool visibleValue)
        {
            _visibleValue = visibleValue;
        }

        public static BooleanToVisibilityConverter VisibleWhenTrue { get; } = new BooleanToVisibilityConverter(true);

        public static BooleanToVisibilityConverter VisibleWhenFalse { get; } = new BooleanToVisibilityConverter(false);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value == _visibleValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible ? _visibleValue : !_visibleValue;
        }
    }
}
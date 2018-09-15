namespace RefMan.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using RefMan.Models;

    [ValueConversion(typeof(Reference), typeof(string))]
    internal class InTextReferenceConverter : IValueConverter
    {
        public static InTextReferenceConverter Default { get; } = new InTextReferenceConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Reference reference = (Reference)value;

            return $"({reference.WebsiteName}, {reference.YearPublished})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
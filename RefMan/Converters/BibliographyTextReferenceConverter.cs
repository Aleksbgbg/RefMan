namespace RefMan.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using RefMan.Models;

    [ValueConversion(typeof(Reference), typeof(string))]
    internal class BibliographyTextReferenceConverter : IValueConverter
    {
        public static BibliographyTextReferenceConverter Default { get; } = new BibliographyTextReferenceConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Reference reference = (Reference)value;

            return $"{reference.WebsiteName}. ({reference.YearPublished}) {reference.PageTitle}. [online] Available at: {reference.Url} [Accessed {reference.AccessDate:dd MMM. yy}]";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
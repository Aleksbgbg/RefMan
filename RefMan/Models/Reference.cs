namespace RefMan.Models
{
    using System;

    using Newtonsoft.Json;

    internal class Reference : IFormattable
    {
        public Reference()
        {
        }

        public Reference(string url, string imageUrl, string pageTitle, string websiteName, DateTime accessDate)
            : this(url, imageUrl, pageTitle, websiteName, accessDate, null)
        {
        }

        [JsonConstructor]
        public Reference(string url, string imageUrl, string pageTitle, string websiteName, DateTime accessDate, int? yearPublished)
        {
            Url = url;
            ImageUrl = imageUrl;
            PageTitle = pageTitle;
            WebsiteName = websiteName;
            //Publisher = publisher;
            AccessDate = accessDate;
            YearPublished = yearPublished;
        }

        [JsonProperty("url")]
        public string Url { get; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; }

        [JsonProperty("page_title")]
        public string PageTitle { get; }

        [JsonProperty("website_name")]
        public string WebsiteName { get; }

        //[JsonProperty("publisher")]
        //public string Publisher { get; }

        [JsonProperty("access_date")]
        public DateTime AccessDate { get; }

        [JsonProperty("year_published")]
        public int? YearPublished { get; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentException("Format specifier has no value.");
            }

            string yearPublishedString = YearPublished == null ? "n.d." : YearPublished.ToString();

            switch (format.ToUpperInvariant())
            {
                case "IT": // In-Text
                    return $"({WebsiteName}, {yearPublishedString})";

                case "IB": // In-Bibliography
                    return $"{WebsiteName}. ({yearPublishedString}) {PageTitle}. [online] Available at: {Url} [Accessed {AccessDate:dd MMM. yy}]";

                default:
                    throw new ArgumentOutOfRangeException("Format specifier is unexpected.");
            }
        }
    }
}
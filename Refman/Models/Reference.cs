namespace Refman.Models
{
    using System;
    using System.ComponentModel;

    using Caliburn.Micro;

    using Newtonsoft.Json;

    internal class Reference : PropertyChangedBase, IFormattable
    {
        public Reference()
        {
        }

        public Reference(string url)
        {
            Url = url;
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

        private string _url;
        [JsonProperty("url")]
        [DisplayName("URL")]
        [Description("The URL of the referenced webpage.")]
        public string Url
        {
            get => _url;

            set
            {
                if (_url == value) return;

                _url = value;
                NotifyOfPropertyChange(() => Url);
            }
        }

        private string _imageUrl;
        [JsonProperty("image_url")]
        [Browsable(false)] // Prevents PropertyGrid generation for this property
        public string ImageUrl
        {
            get => _imageUrl;

            set
            {
                if (_imageUrl == value) return;

                _imageUrl = value;
                NotifyOfPropertyChange(() => ImageUrl);
            }
        }

        private string _pageTitle;
        [JsonProperty("page_title")]
        [DisplayName("Page Title")]
        [Description("The title of the referenced webpage.")]
        public string PageTitle
        {
            get => _pageTitle;

            set
            {
                if (_pageTitle == value) return;

                _pageTitle = value;
                NotifyOfPropertyChange(() => PageTitle);
            }
        }

        private string _websiteName;
        [JsonProperty("website_name")]
        [DisplayName("Website Name")]
        [Description("The name of the referenced website.")]
        public string WebsiteName
        {
            get => _websiteName;

            set
            {
                if (_websiteName == value) return;

                _websiteName = value;
                NotifyOfPropertyChange(() => WebsiteName);
            }
        }

        //[JsonProperty("publisher")]
        //public string Publisher { get; }

        private DateTime _accessDate;
        [JsonProperty("access_date")]
        [DisplayName("Access Date")]
        [Description("The date on which the webpage was accessed.")]
        public DateTime AccessDate
        {
            get => _accessDate;

            set
            {
                if (_accessDate == value) return;

                _accessDate = value;
                NotifyOfPropertyChange(() => AccessDate);
            }
        }

        private int? _yearPublished;
        [JsonProperty("year_published")]
        [DisplayName("Year Published")]
        [Description("The year in which the webpage was published.")]
        public int? YearPublished
        {
            get => _yearPublished;

            set
            {
                if (_yearPublished == value) return;

                _yearPublished = value;
                NotifyOfPropertyChange(() => YearPublished);
            }
        }

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
                    return $"{WebsiteName}. ({yearPublishedString}). {PageTitle}. [online] Available at: {Url} [Accessed {AccessDate:dd MMM. yy}].";

                default:
                    throw new ArgumentOutOfRangeException("Format specifier is unexpected.");
            }
        }
    }
}
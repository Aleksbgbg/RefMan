namespace RefMan.Models
{
    using System;

    using Newtonsoft.Json;

    internal class Reference
    {
        [JsonConstructor]
        public Reference(string url, string pageTitle, string websiteName, string publisher, DateTime accessDate, int yearPublished)
        {
            Url = url;
            PageTitle = pageTitle;
            WebsiteName = websiteName;
            Publisher = publisher;
            AccessDate = accessDate;
            YearPublished = yearPublished;
        }

        [JsonProperty("Url")]
        public string Url { get; }

        [JsonProperty("Url")]
        public string PageTitle { get; }

        [JsonProperty("WebsiteName")]
        public string WebsiteName { get; }

        [JsonProperty("Publisher")]
        public string Publisher { get; }

        [JsonProperty("AccessDate")]
        public DateTime AccessDate { get; }

        [JsonProperty("YearPublished")]
        public int YearPublished { get; }
    }
}
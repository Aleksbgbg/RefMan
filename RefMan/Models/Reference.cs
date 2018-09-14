namespace RefMan.Models
{
    using System;

    internal class Reference
    {
        public Reference(string url, string pageTitle, string websiteName, string publisher, DateTime accessDate, int yearPublished)
        {
            Url = url;
            PageTitle = pageTitle;
            WebsiteName = websiteName;
            Publisher = publisher;
            AccessDate = accessDate;
            YearPublished = yearPublished;
        }

        public string Url { get; }

        public string PageTitle { get; }

        public string WebsiteName { get; }

        public string Publisher { get; }

        public DateTime AccessDate { get; }

        public int YearPublished { get; }
    }
}
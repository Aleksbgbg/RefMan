namespace RefMan.Services
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using HtmlAgilityPack;

    using RefMan.Models;
    using RefMan.Services.Interfaces;

    internal class ReferencingService : IReferencingService
    {
        private readonly HtmlWeb _htmlWeb = new HtmlWeb();

        public async Task<Reference> Reference(string url)
        {
            HtmlDocument document = await _htmlWeb.LoadFromWebAsync(url);

            HtmlNode headNode = document.DocumentNode.SelectSingleNode("/html/head");

            Uri uri = new Uri(url);

            if (headNode == null)
            {
                return new Reference(url, null, null, uri.Host, DateTime.Now);
            }

            string imageUrl = headNode.SelectSingleNode("link[@href and (@rel='icon' or @rel='shortcut icon')]")?.Attributes["href"].Value;

            if (imageUrl == null)
            {
                imageUrl = $"http://{uri.Host}/favicon.ico";
            }
            else if (Uri.IsWellFormedUriString(imageUrl, UriKind.Relative))
            {
                imageUrl = imageUrl.Insert(0, $"{uri.Scheme}://{uri.Host}");
            }

            string pageTitle = headNode.SelectSingleNode("meta[@content and @property='og:title']")?.Attributes["content"].Value ??
                               headNode.SelectSingleNode("title")?.InnerText ??
                               "Unknown";

            pageTitle = WebUtility.HtmlDecode(pageTitle).Trim();

            string websiteName = headNode.SelectSingleNode("meta[@content and @property='og:site_name']")?.Attributes["content"].Value ??
                                 uri.Host;

            websiteName = WebUtility.HtmlDecode(websiteName).Trim();

            return new Reference(url, imageUrl, pageTitle, websiteName, DateTime.Now);
        }
    }
}
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
            Reference reference = new Reference(url);

            await CompleteReference(reference);

            return reference;
        }

        public async Task CompleteReference(Reference reference)
        {
            reference.AccessDate = DateTime.Now;

            HtmlDocument document = await _htmlWeb.LoadFromWebAsync(reference.Url);

            HtmlNode headNode = document.DocumentNode.SelectSingleNode("/html/head");

            Uri uri = new Uri(reference.Url);

            if (headNode == null)
            {
                reference.WebsiteName = uri.Host;
                return;
            }

            string imageUrl = headNode.SelectSingleNode("link[@href and (@rel='icon' or @rel='shortcut icon')]")
                                      ?.Attributes["href"]
                                      .Value;

            if (imageUrl == null)
            {
                imageUrl = $"http://{uri.Host}/favicon.ico";
            }
            else if (Uri.IsWellFormedUriString(imageUrl, UriKind.Relative))
            {
                imageUrl = imageUrl.Insert(0, $"{uri.Scheme}://{uri.Host}");
            }

            string pageTitle = headNode.SelectSingleNode("meta[@content and @property='og:title']")
                                       ?.Attributes["content"]
                                       .Value ??
                               headNode.SelectSingleNode("title")
                                       ?.InnerText ??
                               "Unknown";

            pageTitle = WebUtility.HtmlDecode(pageTitle)
                                  .Trim();

            string websiteName = headNode.SelectSingleNode("meta[@content and @property='og:site_name']")
                                         ?.Attributes["content"]
                                         .Value ??
                                 uri.Host;

            websiteName = WebUtility.HtmlDecode(websiteName)
                                    .Trim();

            reference.ImageUrl = imageUrl;
            reference.PageTitle = pageTitle;
            reference.WebsiteName = websiteName;
        }

        public async Task ReloadReference(Reference reference)
        {
            Reference reloadedReference = await Reference(reference.Url);

            reference.ImageUrl = reloadedReference.ImageUrl;
            reference.PageTitle = reloadedReference.PageTitle;
            reference.WebsiteName = reloadedReference.WebsiteName;
        }
    }
}
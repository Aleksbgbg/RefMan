namespace RefMan.Services
{
    using System.Diagnostics;

    using RefMan.Services.Interfaces;

    internal class WebService : IWebService
    {
        public void OpenInBrowser(string url)
        {
            Process.Start(url);
        }
    }
}
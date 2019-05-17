namespace Refman.Services
{
    using System.Diagnostics;

    using Refman.Services.Interfaces;

    internal class WebService : IWebService
    {
        public void OpenInBrowser(string url)
        {
            Process.Start(url);
        }
    }
}
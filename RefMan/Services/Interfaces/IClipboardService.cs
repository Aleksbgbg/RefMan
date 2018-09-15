namespace RefMan.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RefMan.Models;

    internal interface IClipboardService
    {
        Task CopyToClipboard(IEnumerable<Reference> references);
    }
}
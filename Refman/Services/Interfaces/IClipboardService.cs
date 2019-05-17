namespace Refman.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Refman.Models;

    internal interface IClipboardService
    {
        Task CopyToClipboard(IEnumerable<Reference> references);
    }
}
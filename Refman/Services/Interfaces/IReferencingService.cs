namespace Refman.Services.Interfaces
{
    using System.Threading.Tasks;

    using Refman.Models;

    internal interface IReferencingService
    {
        Task<Reference> Reference(string url);

        Task CompleteReference(Reference reference);

        Task ReloadReference(Reference reference);
    }
}
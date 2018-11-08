namespace RefMan.Services.Interfaces
{
    using System.Threading.Tasks;

    using RefMan.Models;

    internal interface IReferencingService
    {
        Task<Reference> Reference(string url);

        Task CompleteReference(Reference reference);

        Task ReloadReference(Reference reference);
    }
}
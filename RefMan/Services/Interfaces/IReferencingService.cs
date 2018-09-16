namespace RefMan.Services.Interfaces
{
    using System.Threading.Tasks;

    using RefMan.Models;

    internal interface IReferencingService
    {
        Task<Reference> Reference(string url);

        Task ReloadReference(Reference reference);
    }
}
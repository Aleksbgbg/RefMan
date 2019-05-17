namespace Refman.ViewModels.Interfaces
{
    using System.Threading.Tasks;

    using Refman.Models;

    internal interface IReferencesViewModel : IViewModelBase
    {
        Task Add(ReferenceResult referenceResult);
    }
}
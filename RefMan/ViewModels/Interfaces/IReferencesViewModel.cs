namespace RefMan.ViewModels.Interfaces
{
    using System.Threading.Tasks;

    using RefMan.Models;

    internal interface IReferencesViewModel : IViewModelBase
    {
        Task Add(ReferenceResult referenceResult);
    }
}
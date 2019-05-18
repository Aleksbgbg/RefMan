namespace Refman.ViewModels.Interfaces
{
    using Refman.Models;

    internal interface IReferencesViewModel : IViewModelBase
    {
        void Add(ReferenceResult referenceResult);
    }
}
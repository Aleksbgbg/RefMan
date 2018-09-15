namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IReferencesViewModel : IViewModelBase
    {
        void Add(Reference reference);
    }
}
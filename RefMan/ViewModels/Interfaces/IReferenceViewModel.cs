namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IReferenceViewModel : IViewModelBase
    {
        void Initialize(Reference reference);
    }
}
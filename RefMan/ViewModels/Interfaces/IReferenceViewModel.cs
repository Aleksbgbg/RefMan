namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IReferenceViewModel : IViewModelBase
    {
        Reference Reference { get; }

        void Initialize(Reference reference);
    }
}
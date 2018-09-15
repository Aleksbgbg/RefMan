namespace RefMan.ViewModels
{
    using Caliburn.Micro;

    using RefMan.ViewModels.Interfaces;

    internal class ReferencesViewModel : ViewModelBase, IReferencesViewModel
    {
        public IObservableCollection<IReferenceViewModel> References { get; } = new BindableCollection<IReferenceViewModel>();
    }
}
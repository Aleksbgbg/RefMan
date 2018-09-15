namespace RefMan.ViewModels
{
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceGeneratorViewModel : ViewModelBase, IReferenceGeneratorViewModel
    {
        public ReferenceGeneratorViewModel(IReferencesViewModel referencesViewModel)
        {
            ReferencesViewModel = referencesViewModel;
        }

        public IReferencesViewModel ReferencesViewModel { get; }
    }
}
namespace Refman.ViewModels
{
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal class ReferenceGeneratorViewModel : ViewModelBase, IReferenceGeneratorViewModel
    {
        public ReferenceGeneratorViewModel(IReferencesViewModel referencesViewModel)
        {
            ReferencesViewModel = referencesViewModel;
        }

        public IReferencesViewModel ReferencesViewModel { get; }

        public void Reference(string urls)
        {
            foreach (string url in urls.Split('\n'))
            {
                ReferencesViewModel.Add(new ReferenceResult(new Reference(url)));
            }
        }
    }
}
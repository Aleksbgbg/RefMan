namespace RefMan.ViewModels
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceGeneratorViewModel : ViewModelBase, IReferenceGeneratorViewModel
    {
        public ReferenceGeneratorViewModel(IReferencesViewModel referencesViewModel)
        {
            ReferencesViewModel = referencesViewModel;
        }

        public IReferencesViewModel ReferencesViewModel { get; }

        public IEnumerable<IResult> Reference(string urls)
        {
            foreach (string url in urls.Split('\n'))
            {
                yield return ReferencesViewModel.Add(new ReferenceResult(new Reference(url))).AsResult();
            }
        }
    }
}
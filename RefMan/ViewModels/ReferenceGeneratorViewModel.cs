namespace RefMan.ViewModels
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceGeneratorViewModel : ViewModelBase, IReferenceGeneratorViewModel
    {
        private readonly IReferencingService _referencingService;

        public ReferenceGeneratorViewModel(IReferencingService referencingService, IReferencesViewModel referencesViewModel)
        {
            _referencingService = referencingService;
            ReferencesViewModel = referencesViewModel;
        }

        public IReferencesViewModel ReferencesViewModel { get; }

        public IEnumerable<IResult> Reference(string urls)
        {
            foreach (string url in urls.Split('\n'))
            {
                TaskResult<Reference> referenceTask = _referencingService.Reference(url).AsResult();

                yield return referenceTask;

                ReferencesViewModel.Add(referenceTask.Result);
            }
        }
    }
}
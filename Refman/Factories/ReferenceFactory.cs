namespace Refman.Factories
{
    using Caliburn.Micro;

    using Refman.Factories.Interfaces;
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal class ReferenceFactory : IReferenceFactory
    {
        public IReferenceViewModel MakeReference()
        {
            IReferenceViewModel referenceViewModel = IoC.Get<IReferenceViewModel>();
            return referenceViewModel;
        }

        public IReferenceViewModel MakeReference(Reference reference, File referenceFile)
        {
            IReferenceViewModel referenceViewModel = IoC.Get<IReferenceViewModel>();
            referenceViewModel.Initialize(reference, referenceFile);

            return referenceViewModel;
        }
    }
}
namespace RefMan.Factories
{
    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceFactory : IReferenceFactory
    {
        public IReferenceViewModel MakeReference(Reference reference)
        {
            IReferenceViewModel referenceViewModel = IoC.Get<IReferenceViewModel>();
            referenceViewModel.Initialize(reference);

            return referenceViewModel;
        }
    }
}
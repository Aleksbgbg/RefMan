namespace RefMan.Factories.Interfaces
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal interface IReferenceFactory
    {
        IReferenceViewModel MakeReference();

        IReferenceViewModel MakeReference(Reference reference, File referenceFile);
    }
}
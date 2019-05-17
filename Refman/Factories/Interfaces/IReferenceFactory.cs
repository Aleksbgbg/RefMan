namespace Refman.Factories.Interfaces
{
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal interface IReferenceFactory
    {
        IReferenceViewModel MakeReference();

        IReferenceViewModel MakeReference(Reference reference, File referenceFile);
    }
}
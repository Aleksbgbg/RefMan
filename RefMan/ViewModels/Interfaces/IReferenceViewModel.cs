namespace RefMan.ViewModels.Interfaces
{
    using System.Threading.Tasks;

    using RefMan.Models;

    internal interface IReferenceViewModel : IViewModelBase
    {
        ReferenceResult ReferenceResult { get; }

        void Initialize(Reference reference, File referenceFile);

        Task Initialize(ReferenceResult referenceResult, File referenceFile);
    }
}
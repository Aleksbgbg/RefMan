namespace Refman.ViewModels.Interfaces
{
    using System.Threading.Tasks;

    using Refman.Models;

    internal interface IReferenceViewModel : IViewModelBase
    {
        ReferenceResult ReferenceResult { get; }

        void Initialize(Reference reference, File referenceFile);

        Task Initialize(ReferenceResult referenceResult, File referenceFile);
    }
}
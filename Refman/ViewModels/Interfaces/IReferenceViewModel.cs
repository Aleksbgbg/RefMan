namespace Refman.ViewModels.Interfaces
{
    using Refman.Models;

    internal interface IReferenceViewModel : IViewModelBase
    {
        ReferenceResult ReferenceResult { get; }
    }
}
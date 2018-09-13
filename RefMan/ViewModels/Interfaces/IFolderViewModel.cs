namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFolderViewModel : IViewModelBase
    {
        bool IsExpanded { get; set; }

        void Initialize(Folder folder);
    }
}
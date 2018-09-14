namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFolderViewModel : IFileSystemEntryViewModel<Folder>
    {
        bool IsExpanded { get; set; }

        void Initialize(Folder folder);
    }
}
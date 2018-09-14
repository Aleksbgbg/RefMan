namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFolderViewModel : IFileSystemEntryViewModel<Folder>
    {
        void Initialize(Folder folder);
    }
}
namespace Refman.ViewModels.Interfaces
{
    using Refman.Models;

    internal interface IFolderViewModel : IFileSystemEntryViewModel<Folder>
    {
        void Initialize(Folder folder);
    }
}
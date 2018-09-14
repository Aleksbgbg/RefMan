namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFileViewModel : IFileSystemEntryViewModel<File>
    {
        void Initialize(File file);
    }
}
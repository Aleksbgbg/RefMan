namespace RefMan.ViewModels
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal abstract class FileSystemEntryViewModel<T> : ViewModelBase, IFileSystemEntryViewModel<T> where T : FileSystemEntry
    {
        public T FileSystemEntry { get; protected set; }
    }
}
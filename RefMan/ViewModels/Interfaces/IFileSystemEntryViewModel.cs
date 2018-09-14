namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFileSystemEntryViewModel<out T> where T : FileSystemEntry
    {
        bool IsExpanded { get; set; }

        T FileSystemEntry { get; }
    }
}
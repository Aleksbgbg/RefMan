namespace Refman.ViewModels.Interfaces
{
    using Refman.Models;

    internal interface IFileSystemEntryViewModel<out T> where T : FileSystemEntry
    {
        bool IsExpanded { get; set; }

        T FileSystemEntry { get; }
    }
}
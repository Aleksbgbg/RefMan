namespace RefMan.Services.Interfaces
{
    using RefMan.Models;

    internal interface IFileSystemService
    {
        Folder ReadRootFolder();

        FileSystemEntry[] ReadRootEntries();

        FileSystemEntry[] ReadEntries(Folder folder);

        bool CanExpand(Folder folder);
    }
}
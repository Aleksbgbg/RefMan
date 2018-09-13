namespace RefMan.Services.Interfaces
{
    using RefMan.Models;

    internal interface IFileSystemService
    {
        FileSystemEntry[] ReadRootEntries();

        FileSystemEntry[] ReadEntries(Folder folder);
    }
}
namespace RefMan.Services.Interfaces
{
    using RefMan.Models;

    internal interface IFileSystemService
    {
        Folder ReadRootFolder();

        FileSystemEntry[] ReadEntries(Folder folder);

        bool CanExpand(Folder folder);

        Reference[] LoadReferences(File file);

        void SaveFile(File file);
    }
}
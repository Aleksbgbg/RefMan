namespace Refman.Services.Interfaces
{
    using Refman.Models;

    internal interface IFileSystemService
    {
        Folder ReadRootFolder();

        FileSystemEntry[] ReadEntries(Folder folder);

        Folder[] ReadFolders(Folder folder);

        File[] ReadFiles(Folder folder);

        bool CanExpand(Folder folder);

        void SaveFolderConfig(Folder folder);

        Reference[] LoadReferences(File file);

        void SaveFile(File file);
    }
}
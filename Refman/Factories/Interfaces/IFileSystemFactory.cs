namespace Refman.Factories.Interfaces
{
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal interface IFileSystemFactory
    {
        IFileViewModel MakeFile(File file);

        IFolderViewModel MakeFolder(Folder folder);
    }
}
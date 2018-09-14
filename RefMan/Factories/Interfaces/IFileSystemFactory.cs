namespace RefMan.Factories.Interfaces
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal interface IFileSystemFactory
    {
        IFileViewModel MakeFile(File file);

        IFolderViewModel MakeFolder(Folder folder);
    }
}
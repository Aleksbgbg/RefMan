namespace RefMan.Factories.Interfaces
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal interface IFileSystemFactory
    {
        IFolderViewModel MakeFolder(Folder folder);
    }
}
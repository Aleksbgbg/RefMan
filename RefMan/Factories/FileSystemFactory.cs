namespace RefMan.Factories
{
    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class FileSystemFactory : IFileSystemFactory
    {
        public IFolderViewModel MakeFolder(Folder folder)
        {
            IFolderViewModel folderViewModel = IoC.Get<IFolderViewModel>();
            folderViewModel.Initialize(folder);

            return folderViewModel;
        }
    }
}
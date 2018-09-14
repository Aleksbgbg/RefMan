namespace RefMan.Factories
{
    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class FileSystemFactory : IFileSystemFactory
    {
        public IFileViewModel MakeFile(File file)
        {
            IFileViewModel fileViewModel = IoC.Get<IFileViewModel>();
            fileViewModel.Initialize(file);

            return fileViewModel;
        }

        public IFolderViewModel MakeFolder(Folder folder)
        {
            IFolderViewModel folderViewModel = IoC.Get<IFolderViewModel>();
            folderViewModel.Initialize(folder);

            return folderViewModel;
        }
    }
}
namespace Refman.Factories
{
    using Caliburn.Micro;

    using Refman.Factories.Interfaces;
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

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
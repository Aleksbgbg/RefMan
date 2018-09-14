namespace RefMan.ViewModels
{
    using RefMan.Factories.Interfaces;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class FileSystemViewModel : ViewModelBase, IFileSystemViewModel
    {
        public FileSystemViewModel(IFileSystemFactory fileSystemFactory, IFileSystemService fileSystemService)
        {
            IFolderViewModel rootFolder = fileSystemFactory.MakeFolder(fileSystemService.ReadRootFolder());

            RootFolderArray = new[] { rootFolder };

            rootFolder.IsExpanded = true;
        }

        public IFolderViewModel[] RootFolderArray { get; }
    }
}
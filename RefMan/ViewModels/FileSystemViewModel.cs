namespace RefMan.ViewModels
{
    using RefMan.Factories.Interfaces;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class FileSystemViewModel : ViewModelBase, IFileSystemViewModel
    {
        public FileSystemViewModel(IFileSystemFactory fileSystemFactory, IFileSystemService fileSystemService)
        {
            RootFolder = fileSystemFactory.MakeFolder(fileSystemService.ReadRootFolder());
        }

        public IFolderViewModel RootFolder { get; }
    }
}
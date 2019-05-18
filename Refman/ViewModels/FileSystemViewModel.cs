namespace Refman.ViewModels
{
    using Caliburn.Micro;

    using Refman.Services.Interfaces;
    using Refman.ViewModels.Interfaces;

    using Wingman.ServiceFactory;

    internal class FileSystemViewModel : ViewModelBase, IFileSystemViewModel
    {
        private readonly IServiceFactory _serviceFactory;

        private readonly IFileSystemService _fileSystemService;

        public FileSystemViewModel(IServiceFactory serviceFactory, IFileSystemService fileSystemService, ISettingsService settingsService)
        {
            _serviceFactory = serviceFactory;
            _fileSystemService = fileSystemService;

            PopulateRoot();

            settingsService["References Path"].ValueChanged += (sender, e) => PopulateRoot();
        }

        public IObservableCollection<IFolderViewModel> RootFolderCollection { get; } = new BindableCollection<IFolderViewModel>();

        private void PopulateRoot()
        {
            IFolderViewModel rootFolder = _serviceFactory.Make<IFolderViewModel>(_fileSystemService.ReadRootFolder());

            rootFolder.IsExpanded = true;

            RootFolderCollection.Clear();
            RootFolderCollection.Add(rootFolder);
        }
    }
}
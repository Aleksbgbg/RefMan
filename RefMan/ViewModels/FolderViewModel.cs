namespace RefMan.ViewModels
{
    using System.Linq;

    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class FolderViewModel : ViewModelBase, IFolderViewModel
    {
        private readonly IFileSystemFactory _fileSystemFactory;

        private readonly IFileSystemService _fileSystemService;

        public FolderViewModel(IFileSystemFactory fileSystemFactory, IFileSystemService fileSystemService)
        {
            _fileSystemFactory = fileSystemFactory;
            _fileSystemService = fileSystemService;
        }

        public Folder Folder { get; private set; }

        public IObservableCollection<IFolderViewModel> Folders { get; } = new BindableCollection<IFolderViewModel>();

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;

            set
            {
                if (_isExpanded == value) return;

                _isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);

                if (_isExpanded)
                {
                    Folders.AddRange(_fileSystemService.ReadEntries(Folder)
                                                       .Where(entry => entry is Folder)
                                                       .Cast<Folder>()
                                                       .Select(_fileSystemFactory.MakeFolder));
                }
                else
                {
                    Folders.Clear();
                }
            }
        }

        public void Initialize(Folder folder)
        {
            Folder = folder;
        }
    }
}
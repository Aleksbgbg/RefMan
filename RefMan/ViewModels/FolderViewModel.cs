namespace RefMan.ViewModels
{
    using System;
    using System.Linq;

    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class FolderViewModel : FileSystemEntryViewModel<Folder>, IFolderViewModel
    {
        private readonly IFileSystemFactory _fileSystemFactory;

        private readonly IFileSystemService _fileSystemService;

        private bool _canExpand;

        public FolderViewModel(IFileSystemFactory fileSystemFactory, IFileSystemService fileSystemService)
        {
            _fileSystemFactory = fileSystemFactory;
            _fileSystemService = fileSystemService;
        }

        public IObservableCollection<IFileSystemEntryViewModel<FileSystemEntry>> FileSystemEntries { get; } = new BindableCollection<IFileSystemEntryViewModel<FileSystemEntry>>();

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;

            set
            {
                if (!_canExpand || _isExpanded == value) return;

                _isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);

                FileSystemEntries.Clear();

                if (_isExpanded)
                {
                    FileSystemEntries.AddRange(_fileSystemService.ReadEntries(FileSystemEntry)
                                                       .Select<FileSystemEntry, IFileSystemEntryViewModel<FileSystemEntry>>(entry =>
                                                       {
                                                           switch (entry)
                                                           {
                                                               case File file:
                                                                   return _fileSystemFactory.MakeFile(file);

                                                               case Folder folder:
                                                                   return _fileSystemFactory.MakeFolder(folder);

                                                               default:
                                                                   throw new ArgumentException("Invalid FileSystemEntry type.");
                                                           }
                                                       }));
                }
                else
                {
                    AddDummyFolder();
                }
            }
        }

        public void Initialize(Folder folder)
        {
            FileSystemEntry = folder;

            _canExpand = _fileSystemService.CanExpand(FileSystemEntry);
            AddDummyFolder();
        }

        private void AddDummyFolder()
        {
            if (_canExpand)
            {
                FileSystemEntries.Add(null);
            }
        }
    }
}
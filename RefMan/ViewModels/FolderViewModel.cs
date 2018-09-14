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

        public override bool IsExpanded
        {
            get => base.IsExpanded;

            set
            {
                if (!_canExpand || base.IsExpanded == value) return;

                base.IsExpanded = value;

                FileSystemEntries.Clear();

                if (base.IsExpanded)
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
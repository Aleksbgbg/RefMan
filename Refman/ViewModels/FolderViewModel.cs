namespace Refman.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    using Refman.Models;
    using Refman.Services.Interfaces;
    using Refman.ViewModels.Interfaces;

    using Wingman.ServiceFactory;

    internal class FolderViewModel : FileSystemEntryViewModel<Folder>, IFolderViewModel
    {
        private readonly IServiceFactory _serviceFactory;

        private readonly IFileSystemService _fileSystemService;

        private readonly bool _canExpand;

        public FolderViewModel(IServiceFactory serviceFactory, IFileSystemService fileSystemService, Folder folder) : base(folder)
        {
            _serviceFactory = serviceFactory;
            _fileSystemService = fileSystemService;

            _canExpand = _fileSystemService.CanExpand(folder);
            IsExpanded = folder.IsExpanded;
            AddDummyFolder();
        }

        public IObservableCollection<IFileSystemEntryViewModel<FileSystemEntry>> FileSystemEntries { get; } = new BindableCollection<IFileSystemEntryViewModel<FileSystemEntry>>();

        public sealed override bool IsExpanded
        {
            get => base.IsExpanded;

            set
            {
                if (!_canExpand || base.IsExpanded == value) return;

                base.IsExpanded = value;

                if (FileSystemEntry.IsExpanded != value)
                {
                    FileSystemEntry.IsExpanded = value;
                    _fileSystemService.SaveFolderConfig(FileSystemEntry);
                }

                FileSystemEntries.Clear();

                if (base.IsExpanded)
                {
                    PopulateFoldersInDirectory();
                    PopulateFilesInDirectory();
                }
                else
                {
                    AddDummyFolder();
                }
            }
        }

        private void AddDummyFolder()
        {
            if (_canExpand && FileSystemEntries.Count == 0)
            {
                FileSystemEntries.Add(null);
            }
        }

        private void PopulateFoldersInDirectory()
        {
            PopulateEntries<IFolderViewModel>(_fileSystemService.ReadFolders(FileSystemEntry));
        }

        private void PopulateFilesInDirectory()
        {
            PopulateEntries<IFileViewModel>(_fileSystemService.ReadFiles(FileSystemEntry));
        }

        private void PopulateEntries<TViewModel>(IEnumerable<FileSystemEntry> entries) where TViewModel : IFileSystemEntryViewModel<FileSystemEntry>
        {
            FileSystemEntries.AddRange((IEnumerable<IFileSystemEntryViewModel<FileSystemEntry>>)entries.Select(entry => _serviceFactory.Make<TViewModel>(entry)));
        }
    }
}
namespace RefMan.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    using RefMan.Factories.Interfaces;
    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class ReferencesViewModel : ViewModelBase, IReferencesViewModel, IHandle<File>, IHandle<IReferenceViewModel>
    {
        private readonly IReferenceFactory _referenceFactory;

        private readonly IClipboardService _clipboardService;

        private readonly IFileSystemService _fileSystemService;

        public ReferencesViewModel(IReferenceFactory referenceFactory, IEventAggregator eventAggregator, IClipboardService clipboardService, IFileSystemService fileSystemService)
        {
            _referenceFactory = referenceFactory;
            _clipboardService = clipboardService;
            _fileSystemService = fileSystemService;

            eventAggregator.Subscribe(this);
        }

        public IObservableCollection<IReferenceViewModel> References { get; } = new BindableCollection<IReferenceViewModel>();

        private File _loadedFile;
        public File LoadedFile
        {
            get => _loadedFile;

            set
            {
                if (_loadedFile == value) return;

                _loadedFile = value;
                NotifyOfPropertyChange(() => LoadedFile);
            }
        }

        public void Handle(File message)
        {
            if (LoadedFile == message)
            {
                return;
            }

            LoadedFile = message;

            References.Clear();

            if (message.References == null || message.References.Count == 0)
            {
                _fileSystemService.LoadReferences(message);
            }

            References.AddRange(message.References.Select(reference => _referenceFactory.MakeReference(reference, LoadedFile)));
        }

        public void Handle(IReferenceViewModel message)
        {
            References.Remove(message);

            LoadedFile.References.Remove(message.Reference);
            _fileSystemService.SaveFile(LoadedFile);
        }

        public void Add(Reference reference)
        {
            LoadedFile.References.Add(reference);
            _fileSystemService.SaveFile(LoadedFile);

            References.Add(_referenceFactory.MakeReference(reference, LoadedFile));
        }

        public IEnumerable<IResult> CopyReferencesToClipboard()
        {
            yield return _clipboardService.CopyToClipboard(LoadedFile.References).AsResult();
        }
    }
}
namespace RefMan.ViewModels
{
    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceViewModel : ViewModelBase, IReferenceViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IFileSystemService _fileSystemService;

        private readonly IReferencingService _referencingService;

        private File _referenceFile;

        public ReferenceViewModel(IEventAggregator eventAggregator, IFileSystemService fileSystemService, IReferencingService referencingService)
        {
            _eventAggregator = eventAggregator;
            _fileSystemService = fileSystemService;
            _referencingService = referencingService;
        }

        public Reference Reference { get; private set; }

        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;

            set
            {
                if (_isEditing == value) return;

                _isEditing = value;
                NotifyOfPropertyChange(() => IsEditing);

                if (!_isEditing)
                {
                    _fileSystemService.SaveFile(_referenceFile);
                }
            }
        }

        public void Initialize(Reference reference, File referenceFile)
        {
            Reference = reference;
            _referenceFile = referenceFile;

            Reference.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Reference.Url))
                {
                    _referencingService.ReloadReference(Reference);
                }
            };
        }

        public void Delete()
        {
            _eventAggregator.BeginPublishOnUIThread(this);
        }
    }
}
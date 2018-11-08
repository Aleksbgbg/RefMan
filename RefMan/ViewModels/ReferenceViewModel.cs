namespace RefMan.ViewModels
{
    using System.Threading.Tasks;

    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceViewModel : ViewModelBase, IReferenceViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IFileSystemService _fileSystemService;

        private readonly IReferencingService _referencingService;

        private readonly IWebService _webService;

        private File _referenceFile;

        public ReferenceViewModel(IEventAggregator eventAggregator, IFileSystemService fileSystemService, IReferencingService referencingService, IWebService webService)
        {
            _eventAggregator = eventAggregator;
            _fileSystemService = fileSystemService;
            _referencingService = referencingService;
            _webService = webService;
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

            UpdateReferenceOnUrlChanges();
        }

        public async Task Initialize(ReferenceResult referenceResult, File referenceFile)
        {
            Reference = referenceResult.Reference;
            _referenceFile = referenceFile;

            if (!referenceResult.IsComplete)
            {
                await _referencingService.CompleteReference(referenceResult.Reference);

                _referenceFile.References.Add(referenceResult.Reference);
                _fileSystemService.SaveFile(_referenceFile);
            }

            UpdateReferenceOnUrlChanges();
        }

        public void Delete()
        {
            _eventAggregator.BeginPublishOnUIThread(this);
        }

        public void OpenInBrowser()
        {
            _webService.OpenInBrowser(Reference.Url);
        }

        private void UpdateReferenceOnUrlChanges()
        {
            Reference.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Reference.Url))
                {
                    _referencingService.ReloadReference(Reference);
                }
            };
        }
    }
}
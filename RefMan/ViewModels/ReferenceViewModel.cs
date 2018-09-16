namespace RefMan.ViewModels
{
    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceViewModel : ViewModelBase, IReferenceViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IReferencingService _referencingService;

        public ReferenceViewModel(IEventAggregator eventAggregator, IReferencingService referencingService)
        {
            _eventAggregator = eventAggregator;
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
            }
        }

        public void Initialize(Reference reference)
        {
            Reference = reference;

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
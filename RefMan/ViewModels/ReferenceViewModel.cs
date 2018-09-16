namespace RefMan.ViewModels
{
    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceViewModel : ViewModelBase, IReferenceViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public ReferenceViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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
        }

        public void Delete()
        {
            _eventAggregator.BeginPublishOnUIThread(this);
        }
    }
}
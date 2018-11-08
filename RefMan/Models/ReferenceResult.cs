namespace RefMan.Models
{
    using Caliburn.Micro;

    internal class ReferenceResult : PropertyChangedBase
    {
        public ReferenceResult(Reference reference, bool isComplete = true)
        {
            Reference = reference;
            _isComplete = isComplete;
        }

        public Reference Reference { get; }

        private bool _isComplete;
        public bool IsComplete
        {
            get => _isComplete;

            set
            {
                if (_isComplete == value) return;

                _isComplete = value;
                NotifyOfPropertyChange(() => IsComplete);
            }
        }
    }
}
namespace Refman.ViewModels
{
    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal abstract class FileSystemEntryViewModel<T> : ViewModelBase, IFileSystemEntryViewModel<T> where T : FileSystemEntry
    {
        public T FileSystemEntry { get; private protected set; }

        private bool _isExpanded;
        public virtual bool IsExpanded
        {
            get => _isExpanded;

            set
            {
                if (_isExpanded == value) return;

                _isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;

            set
            {
                if (_isSelected == value) return;

                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);

                OnSelected(_isSelected);
            }
        }

        private protected virtual void OnSelected(bool isSelected)
        {
        }
    }
}
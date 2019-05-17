namespace Refman.ViewModels
{
    using Caliburn.Micro;

    using Refman.Models;
    using Refman.ViewModels.Interfaces;

    internal class FileViewModel : FileSystemEntryViewModel<File>, IFileViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public FileViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public override bool IsExpanded
        {
            get => base.IsExpanded;

            set
            {
            }
        }

        public void Initialize(File file)
        {
            FileSystemEntry = file;
        }

        private protected override void OnSelected(bool isSelected)
        {
            if (isSelected)
            {
                _eventAggregator.BeginPublishOnUIThread(FileSystemEntry);
            }
        }
    }
}
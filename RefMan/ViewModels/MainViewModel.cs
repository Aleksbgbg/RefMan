namespace RefMan.ViewModels
{
    using Caliburn.Micro;

    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel, IHandle<File>
    {
        private bool _fileHasBeenSelected;

        public MainViewModel(IEventAggregator eventAggregator, IFileSystemViewModel fileSystemViewModel, IReferenceGeneratorViewModel referenceGeneratorViewModel)
        {
            FileSystemViewModel = fileSystemViewModel;
            _referenceGeneratorViewModel = referenceGeneratorViewModel;

            eventAggregator.Subscribe(this);
        }

        public IFileSystemViewModel FileSystemViewModel { get; }

        private readonly IReferenceGeneratorViewModel _referenceGeneratorViewModel;
        public IReferenceGeneratorViewModel ReferenceGeneratorViewModel => _fileHasBeenSelected ? _referenceGeneratorViewModel : null;

        public void Handle(File message)
        {
            if (!_fileHasBeenSelected)
            {
                _fileHasBeenSelected = true;
                NotifyOfPropertyChange(() => ReferenceGeneratorViewModel);
            }
        }
    }
}
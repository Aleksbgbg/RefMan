namespace RefMan.ViewModels
{
    using RefMan.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFileSystemViewModel fileSystemViewModel, IReferenceGeneratorViewModel referenceGeneratorViewModel)
        {
            FileSystemViewModel = fileSystemViewModel;
            ReferenceGeneratorViewModel = referenceGeneratorViewModel;
        }

        public IFileSystemViewModel FileSystemViewModel { get; }

        public IReferenceGeneratorViewModel ReferenceGeneratorViewModel { get; }
    }
}
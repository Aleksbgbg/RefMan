namespace RefMan.ViewModels
{
    using RefMan.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFileSystemViewModel fileSystemViewModel, IReferencesViewModel referencesViewModel)
        {
            FileSystemViewModel = fileSystemViewModel;
            ReferencesViewModel = referencesViewModel;
        }

        public IFileSystemViewModel FileSystemViewModel { get; }

        public IReferencesViewModel ReferencesViewModel { get; }
    }
}
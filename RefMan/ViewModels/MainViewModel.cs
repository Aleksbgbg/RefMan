namespace RefMan.ViewModels
{
    using RefMan.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFileSystemViewModel fileSystemViewModel)
        {
            FileSystemViewModel = fileSystemViewModel;
        }

        public IFileSystemViewModel FileSystemViewModel { get; }
    }
}
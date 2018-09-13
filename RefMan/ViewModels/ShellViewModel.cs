namespace RefMan.ViewModels
{
    using RefMan.ViewModels.Interfaces;

    internal sealed class ShellViewModel : ViewModelBase, IShellViewModel
    {
        public ShellViewModel(IMainViewModel mainViewModel)
        {
            DisplayName = "RefMan";

            MainViewModel = mainViewModel;
        }

        public IMainViewModel MainViewModel { get; }
    }
}
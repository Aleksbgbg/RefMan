namespace RefMan.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;

    using RefMan.ViewModels.Interfaces;

    internal sealed class ShellViewModel : Conductor<IViewModelBase>.Collection.OneActive, IShellViewModel
    {
        private readonly IMainViewModel _mainViewModel;

        private readonly ISettingsViewModel _settingsViewModel;

        public ShellViewModel(IMainViewModel mainViewModel, ISettingsViewModel settingsViewModel)
        {
            DisplayName = "RefMan";

            _mainViewModel = mainViewModel;
            _settingsViewModel = settingsViewModel;

            ActivateItem(mainViewModel);
        }

        protected override IViewModelBase DetermineNextItemToActivate(IList<IViewModelBase> list, int lastIndex)
        {
            if (list[lastIndex] == _settingsViewModel)
            {
                return _mainViewModel;
            }

            return _settingsViewModel;
        }

        public void OpenSettings()
        {
            ActivateItem(_settingsViewModel);
        }
    }
}
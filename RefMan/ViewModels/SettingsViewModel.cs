namespace RefMan.ViewModels
{
    using RefMan.Services.Interfaces;
    using RefMan.Utilities.PropertyGrid;
    using RefMan.ViewModels.Interfaces;

    internal class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        public SettingsViewModel(ISettingsService settingsService)
        {
            SettingsDescriptor = new SettingsTypeDescriptor(settingsService.Settings);
        }

        public SettingsTypeDescriptor SettingsDescriptor { get; }

        public void Close()
        {
            TryClose();
        }
    }
}
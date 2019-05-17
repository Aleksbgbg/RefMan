namespace Refman.ViewModels
{
    using Refman.Services.Interfaces;
    using Refman.Utilities.PropertyGrid;
    using Refman.ViewModels.Interfaces;

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
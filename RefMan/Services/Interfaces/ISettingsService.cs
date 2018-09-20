namespace RefMan.Services.Interfaces
{
    using RefMan.Models.Settings;

    internal interface ISettingsService
    {
        Setting[] Settings { get; }

        T Get<T>(string key);

        void Set(string key, object value);
    }
}
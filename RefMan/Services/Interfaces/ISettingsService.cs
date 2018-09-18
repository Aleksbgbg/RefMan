namespace RefMan.Services.Interfaces
{
    internal interface ISettingsService
    {
        T Get<T>(string key);

        void Set(string key, object value);
    }
}
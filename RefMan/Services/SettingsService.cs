namespace RefMan.Services
{
    using System;
    using System.Collections.Generic;

    using RefMan.Services.Interfaces;

    internal class SettingsService : ISettingsService
    {
        private readonly Dictionary<string, object> _settings;

        public SettingsService(IDataService dataService)
        {
            _settings = dataService.Load("Settings",
                                         () => new Dictionary<string, object>
                                         {
                                             ["RootPath"] = @"E:\Documents\References"
                                         });
        }

        public T Get<T>(string key)
        {
            return (T)_settings[key];
        }

        public void Set(string key, object value)
        {
            if (!_settings.ContainsKey(key)) // Ensures that no disallowed settings are set
            {
                throw new ArgumentOutOfRangeException("Invalid setting name.");
            }

            _settings[key] = value;
        }
    }
}
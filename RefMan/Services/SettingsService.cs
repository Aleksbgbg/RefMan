namespace RefMan.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;

    using RefMan.Extensions;
    using RefMan.Models.Settings;
    using RefMan.Services.Interfaces;

    internal class SettingsService : ISettingsService
    {
        private readonly IDataService _dataService;

        private readonly Dictionary<string, Setting> _settings = new Dictionary<string, Setting>();

        public SettingsService(IDataService dataService)
        {
            _dataService = dataService;

            Setting[] settings = JsonConvert.DeserializeObject<Setting[]>(Assembly.GetExecutingAssembly()
                                                                                  .ReadFile("RefMan.Resources.Settings.json"));

            {
                object[] settingValues = dataService.Load("Settings",
                                                          () => settings.Select(setting => setting.DefaultValue)
                                                                        .ToArray());

                for (int settingIndex = 0; settingIndex < settings.Length; ++settingIndex)
                {
                    settings[settingIndex].Value = settingValues[settingIndex];
                }
            }

            foreach (Setting setting in settings)
            {
                _settings[setting.Name] = setting;
                setting.ValueChanged += (sender, e) => SaveSettings();
            }
        }

        public Setting this[string key] => _settings[key];

        public Setting[] Settings => _settings.Values.ToArray();

        public T Get<T>(string key)
        {
            return (T)_settings[key].Value;
        }

        public void Set(string key, object value)
        {
            if (!_settings.ContainsKey(key)) // Ensures that no disallowed settings are set
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Invalid setting name.");
            }

            _settings[key].Value = value;

            SaveSettings();
        }

        private void SaveSettings()
        {
            _dataService.Save("Settings", _settings.Values.Select(setting => setting.Value));
        }
    }
}
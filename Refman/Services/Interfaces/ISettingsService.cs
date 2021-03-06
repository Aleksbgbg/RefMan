﻿namespace Refman.Services.Interfaces
{
    using Refman.Models.Settings;

    internal interface ISettingsService
    {
        Setting this[string key] { get; }

        Setting[] Settings { get; }

        T Get<T>(string key);

        void Set(string key, object value);
    }
}
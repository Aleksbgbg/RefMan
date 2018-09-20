namespace RefMan.Models.Settings
{
    using System;

    using Newtonsoft.Json;

    internal class Setting
    {
        [JsonConstructor]
        public Setting(string name, string description, object defaultValue, string editor)
        {
            Name = name;
            Description = description;
            Editor = editor;
            DefaultValue = defaultValue;
        }

        public Setting(string name, string description, object defaultValue, string editor, object value) : this(name, description, defaultValue, editor)
        {
            Value = value;
        }

        public event EventHandler ValueChanged;

        public string Name { get; }

        public string Description { get; }

        public string Editor { get; }

        public object DefaultValue { get; }

        private object _value;
        public object Value
        {
            get => _value;

            set
            {
                _value = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
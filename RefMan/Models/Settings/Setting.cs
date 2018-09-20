namespace RefMan.Models.Settings
{
    using Newtonsoft.Json;

    internal class Setting
    {
        [JsonConstructor]
        public Setting(string name, string description, object defaultValue)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
        }

        public Setting(string name, string description, object defaultValue, object value) : this(name, description, defaultValue)
        {
            Value = value;
        }

        public string Name { get; }

        public string Description { get; }

        public object DefaultValue { get; }

        public object Value { get; set; }
    }
}
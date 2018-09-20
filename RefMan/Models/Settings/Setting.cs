namespace RefMan.Models.Settings
{
    using Newtonsoft.Json;

    internal class Setting
    {
        [JsonConstructor]
        public Setting(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Setting(string name, string description, object value) : this(name, description)
        {
            Value = value;
        }

        public string Name { get; }

        public string Description { get; }

        public object Value { get; set; }
    }
}
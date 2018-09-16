namespace RefMan.Models
{
    using Newtonsoft.Json;

    internal class Folder : FileSystemEntry
    {
        public Folder(string path, string name) : base(path, name)
        {
        }

        [JsonConstructor]
        public Folder(string path, string name, bool isExpanded) : base(path, name)
        {
            IsExpanded = isExpanded;
        }

        [JsonProperty("is_expanded")]
        public bool IsExpanded { get; set; }
    }
}
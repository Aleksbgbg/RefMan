namespace RefMan.Models
{
    using Newtonsoft.Json;

    internal class Folder : FileSystemEntry
    {
        [JsonConstructor]
        public Folder(bool isExpanded)
        {
            IsExpanded = isExpanded;
        }

        public Folder(string path, string name) : base(path, name)
        {
        }

        public Folder(string path, string name, bool isExpanded) : base(path, name)
        {
            IsExpanded = isExpanded;
        }

        [JsonProperty("is_expanded")]
        public bool IsExpanded { get; set; }
    }
}
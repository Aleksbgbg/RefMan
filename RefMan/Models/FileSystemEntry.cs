namespace RefMan.Models
{
    using Newtonsoft.Json;

    internal abstract class FileSystemEntry
    {
        public FileSystemEntry(string path, string name)
        {
            Path = path;
            Name = name;
        }

        [JsonProperty("path")]
        public string Path { get; }

        [JsonProperty("name")]
        public string Name { get; }
    }
}
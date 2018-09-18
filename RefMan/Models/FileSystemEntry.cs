namespace RefMan.Models
{
    using Newtonsoft.Json;

    internal abstract class FileSystemEntry
    {
        public FileSystemEntry()
        {
        }

        public FileSystemEntry(string path, string name)
        {
            Path = path;
            Name = name;
        }

        [JsonIgnore]
        public string Path { get; set; }

        [JsonIgnore]
        public string Name { get; set; }
    }
}
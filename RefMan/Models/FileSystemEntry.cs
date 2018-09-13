namespace RefMan.Models
{
    internal abstract class FileSystemEntry
    {
        public FileSystemEntry(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Path { get; }

        public string Name { get; }
    }
}
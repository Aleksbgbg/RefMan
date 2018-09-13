namespace RefMan.Models
{
    using System.Collections.Generic;

    internal class Folder : FileSystemEntry
    {
        public Folder(string path, string name) : base(path, name)
        {
            FileSystemEntries = new List<FileSystemEntry>();
        }

        public Folder(string path, string name, IEnumerable<FileSystemEntry> fileSystemEntries) : base(path, name)
        {
            FileSystemEntries = new List<FileSystemEntry>(fileSystemEntries);
        }

        public List<FileSystemEntry> FileSystemEntries { get; }
    }
}
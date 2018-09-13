namespace RefMan.Models
{
    using System.Collections.Generic;

    internal class Folder : FileSystemEntry
    {
        public Folder(string name) : base(name)
        {
            FileSystemEntries = new List<FileSystemEntry>();
        }

        public Folder(string name, IEnumerable<FileSystemEntry> fileSystemEntries) : base(name)
        {
            FileSystemEntries = new List<FileSystemEntry>(fileSystemEntries);
        }

        public List<FileSystemEntry> FileSystemEntries { get; }
    }
}
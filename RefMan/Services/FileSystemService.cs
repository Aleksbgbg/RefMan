namespace RefMan.Services
{
    using System.IO;
    using System.Linq;

    using RefMan.Models;
    using RefMan.Services.Interfaces;

    using File = RefMan.Models.File;

    internal class FileSystemService : IFileSystemService
    {
        private const string Root = @"E:\Documents\References";

        public FileSystemService()
        {
            Directory.CreateDirectory(Root);
        }

        public Folder ReadRootFolder()
        {
            return new Folder(Root, Path.GetFileName(Root), ReadEntries(Root));
        }

        public FileSystemEntry[] ReadRootEntries()
        {
            return ReadEntries(Root);
        }

        public FileSystemEntry[] ReadEntries(Folder folder)
        {
            return ReadEntries(folder.Path);
        }

        private static FileSystemEntry[] ReadEntries(string path)
        {
            return Directory.GetDirectories(path)
                            .Select(directory => new Folder(directory, Path.GetFileName(directory)))
                            .Concat<FileSystemEntry>(Directory.GetFiles(path).Select(file => new File(file, Path.GetFileNameWithoutExtension(file))))
                            .ToArray();
        }
    }
}
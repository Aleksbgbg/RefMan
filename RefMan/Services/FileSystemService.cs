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

        private const string RefManExtension = ".ref";

        public FileSystemService()
        {
            Directory.CreateDirectory(Root);
        }

        public Folder ReadRootFolder()
        {
            return new Folder(Root, Path.GetFileName(Root));
        }

        public FileSystemEntry[] ReadRootEntries()
        {
            return ReadEntries(Root);
        }

        public FileSystemEntry[] ReadEntries(Folder folder)
        {
            return ReadEntries(folder.Path);
        }

        public bool CanExpand(Folder folder)
        {
            return Directory.EnumerateFileSystemEntries(folder.Path).Any();
        }

        private static FileSystemEntry[] ReadEntries(string path)
        {
            return Directory.GetDirectories(path)
                            .Select(directory => new Folder(directory, Path.GetFileName(directory)))
                            .Concat<FileSystemEntry>(Directory.GetFiles(path)
                                                              .Where(file => Path.GetExtension(file) == RefManExtension)
                                                              .Select(file => new File(file, Path.GetFileNameWithoutExtension(file))))
                            .ToArray();
        }
    }
}
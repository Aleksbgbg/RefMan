namespace RefMan.Services
{
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using RefMan.Models;
    using RefMan.Services.Interfaces;

    using File = RefMan.Models.File;
    using IOFile = System.IO.File;

    internal class FileSystemService : IFileSystemService
    {
        private const string RefManExtension = ".ref";

        private readonly ISettingsService _settingsService;

        public FileSystemService(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            Directory.CreateDirectory(Root);
        }

        private string Root => _settingsService.Get<string>("References Path");

        public Folder ReadRootFolder()
        {
            string rootFolder = Root;
            return new Folder(rootFolder, Path.GetFileName(rootFolder));
        }

        public FileSystemEntry[] ReadEntries(Folder folder)
        {
            return ReadEntries(folder.Path);
        }

        public bool CanExpand(Folder folder)
        {
            return Directory.EnumerateFileSystemEntries(folder.Path).Any();
        }

        public void SaveFolderConfig(Folder folder)
        {
            string configFile = Path.Combine(folder.Path, "Config.json");

            IOFile.WriteAllText(configFile, JsonConvert.SerializeObject(folder));
        }

        public Reference[] LoadReferences(File file)
        {
            string fileText = IOFile.ReadAllText(file.Path);

            if (string.IsNullOrWhiteSpace(fileText))
            {
                fileText = "[]";
                IOFile.WriteAllText(file.Path, fileText);
            }

            Reference[] references = JsonConvert.DeserializeObject<Reference[]>(fileText);

            file.LoadReferences(references);

            return references;
        }

        public void SaveFile(File file)
        {
            IOFile.WriteAllText(file.Path, JsonConvert.SerializeObject(file.References));
        }

        private static FileSystemEntry[] ReadEntries(string path)
        {
            return Directory.GetDirectories(path)
                            .Select(directory =>
                            {
                                string configFile = Path.Combine(directory, "Config.json");

                                string directoryName = Path.GetFileName(directory);

                                if (IOFile.Exists(configFile))
                                {
                                    Folder folder = JsonConvert.DeserializeObject<Folder>(IOFile.ReadAllText(configFile));

                                    folder.Path = directory;
                                    folder.Name = directoryName;

                                    return folder;
                                }

                                return new Folder(directory, directoryName);
                            })
                            .Concat<FileSystemEntry>(Directory.GetFiles(path)
                                                              .Where(file => Path.GetExtension(file) == RefManExtension)
                                                              .Select(file => new File(file, Path.GetFileNameWithoutExtension(file))))
                            .ToArray();
        }
    }
}
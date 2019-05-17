namespace Refman.Services
{
    using System;
    using System.IO;

    using Refman.Services.Interfaces;

    internal class AppDataService : IAppDataService
    {
        private static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private static readonly string ApplicationPath = Path.Combine(AppDataPath, Constants.AppName);

        public AppDataService()
        {
            Directory.CreateDirectory(ApplicationPath);
        }

        public string GetFolder(string name)
        {
            string directoryPath = Path.Combine(ApplicationPath, name);

            Directory.CreateDirectory(directoryPath);

            return directoryPath;
        }

        public string GetFile(string name, string defaultContents = "")
        {
            return GetFile(name, () => defaultContents);
        }

        public string GetFile(string name, Func<string> defaultContents)
        {
            string filePath = Path.Combine(ApplicationPath, name);

            if (!File.Exists(filePath))
            {
                string directory = Path.GetDirectoryName(filePath);

                Directory.CreateDirectory(directory);

                File.WriteAllText(filePath, defaultContents());
            }

            return filePath;
        }
    }
}
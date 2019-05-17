namespace Refman.Extensions
{
    using System.IO;
    using System.Reflection;

    internal static class AssemblyExtensions
    {
        internal static string ReadFile(this Assembly assembly, string name)
        {
            using (Stream fileStream = assembly.GetManifestResourceStream(name))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
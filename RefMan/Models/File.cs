namespace RefMan.Models
{
    using System.Collections.Generic;

    internal class File : FileSystemEntry
    {
        public File(string path, string name) : base(path, name)
        {
        }

        public List<Reference> References { get; private set; }

        public void LoadReferences(IEnumerable<Reference> references)
        {
            if (References == null)
            {
                References = new List<Reference>(references);
            }
            else
            {
                References.Clear();
                References.AddRange(references);
            }
        }
    }
}
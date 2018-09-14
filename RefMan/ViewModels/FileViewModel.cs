namespace RefMan.ViewModels
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class FileViewModel : FileSystemEntryViewModel<File>, IFileViewModel
    {
        public override bool IsExpanded
        {
            get => base.IsExpanded;

            set
            {
            }
        }

        public void Initialize(File file)
        {
            FileSystemEntry = file;
        }
    }
}
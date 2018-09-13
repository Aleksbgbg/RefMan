namespace RefMan.ViewModels
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class FolderViewModel : ViewModelBase, IFolderViewModel
    {
        public Folder Folder { get; private set; }

        public void Initialize(Folder folder)
        {
            Folder = folder;
        }
    }
}
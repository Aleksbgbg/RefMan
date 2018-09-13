namespace RefMan.ViewModels.Interfaces
{
    using RefMan.Models;

    internal interface IFolderViewModel : IViewModelBase
    {
        void Initialize(Folder folder);
    }
}
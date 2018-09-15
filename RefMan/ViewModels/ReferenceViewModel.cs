namespace RefMan.ViewModels
{
    using RefMan.Models;
    using RefMan.ViewModels.Interfaces;

    internal class ReferenceViewModel : ViewModelBase, IReferenceViewModel
    {
        public Reference Reference { get; private set; }

        public void Initialize(Reference reference)
        {
            Reference = reference;
        }
    }
}
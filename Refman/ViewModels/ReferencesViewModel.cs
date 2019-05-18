namespace Refman.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Caliburn.Micro;

    using Refman.Models;
    using Refman.Services.Interfaces;
    using Refman.ViewModels.Interfaces;

    using Wingman.ServiceFactory;

    internal class ReferencesViewModel : ViewModelBase, IReferencesViewModel, IHandle<File>, IHandle<IReferenceViewModel>
    {
        private readonly IServiceFactory _serviceFactory;

        private readonly IClipboardService _clipboardService;

        private readonly IFileSystemService _fileSystemService;

        public ReferencesViewModel(IServiceFactory serviceFactory, IEventAggregator eventAggregator, IClipboardService clipboardService, IFileSystemService fileSystemService)
        {
            _serviceFactory = serviceFactory;
            _clipboardService = clipboardService;
            _fileSystemService = fileSystemService;

            eventAggregator.Subscribe(this);
        }

        public IObservableCollection<IReferenceViewModel> References { get; } = new BindableCollection<IReferenceViewModel>();

        private File _loadedFile;
        public File LoadedFile
        {
            get => _loadedFile;

            set
            {
                if (_loadedFile == value) return;

                _loadedFile = value;
                NotifyOfPropertyChange(() => LoadedFile);
            }
        }

        public void Handle(File message)
        {
            if (LoadedFile == message)
            {
                return;
            }

            LoadedFile = message;

            References.Clear();

            if (message.References == null || message.References.Count == 0)
            {
                _fileSystemService.LoadReferences(message);
            }

            References.AddRange(message.References.Select(reference => _serviceFactory.Make<IReferenceViewModel>(reference, LoadedFile)));
        }

        public void Handle(IReferenceViewModel message)
        {
            References.Remove(message);

            LoadedFile.References.Remove(message.ReferenceResult.Reference);
            _fileSystemService.SaveFile(LoadedFile);
        }

        public void Add(ReferenceResult referenceResult)
        {
            IReferenceViewModel referenceViewModel = _serviceFactory.Make<IReferenceViewModel>(referenceResult, LoadedFile);

            References.Add(referenceViewModel);
        }

        public IEnumerable<IResult> CopyReferencesToClipboard()
        {
            yield return _clipboardService.CopyToClipboard(LoadedFile.References).AsResult();
        }
    }
}
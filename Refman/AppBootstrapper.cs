namespace Refman
{
    using Caliburn.Micro;

    using Refman.Services;
    using Refman.Services.Interfaces;
    using Refman.ViewModels;
    using Refman.ViewModels.Interfaces;

    using Wingman.Bootstrapper;
    using Wingman.Container;
    using Wingman.ServiceFactory;

    internal class AppBootstrapper : BootstrapperBase<IShellViewModel>
    {
        protected override void RegisterViewModels(IDependencyRegistrar dependencyRegistrar)
        {
            dependencyRegistrar.Singleton<IShellViewModel, ShellViewModel>();
            dependencyRegistrar.Singleton<IMainViewModel, MainViewModel>();

            dependencyRegistrar.Singleton<ISettingsViewModel, SettingsViewModel>();

            dependencyRegistrar.Singleton<IFileSystemViewModel, FileSystemViewModel>();
            dependencyRegistrar.PerRequest<IFolderViewModel, FolderViewModel>();
            dependencyRegistrar.PerRequest<IFileViewModel, FileViewModel>();

            dependencyRegistrar.Singleton<IReferenceGeneratorViewModel, ReferenceGeneratorViewModel>();
            dependencyRegistrar.Singleton<IReferencesViewModel, ReferencesViewModel>();
            dependencyRegistrar.PerRequest<IReferenceViewModel, ReferenceViewModel>();
        }

        protected override void RegisterServices(IDependencyRegistrar dependencyRegistrar)
        {
            dependencyRegistrar.Singleton<IEventAggregator, EventAggregator>();

            dependencyRegistrar.Singleton<IAppDataService, AppDataService>();
            dependencyRegistrar.Singleton<IClipboardService, ClipboardService>();
            dependencyRegistrar.Singleton<IDataService, DataService>();
            dependencyRegistrar.Singleton<IFileSystemService, FileSystemService>();
            dependencyRegistrar.Singleton<IReferencingService, ReferencingService>();
            dependencyRegistrar.Singleton<ISettingsService, SettingsService>();
            dependencyRegistrar.Singleton<IWebService, WebService>();
        }

        protected override void RegisterFactoryViewModels(IServiceFactoryRegistrar dependencyRegistrar)
        {
            dependencyRegistrar.Register<IFolderViewModel, FolderViewModel>();
            dependencyRegistrar.Register<IFileViewModel, FileViewModel>();

            dependencyRegistrar.Register<IReferenceViewModel, ReferenceViewModel>();
        }
    }
}
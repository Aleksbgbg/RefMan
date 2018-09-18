namespace RefMan
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using RefMan.Factories;
    using RefMan.Factories.Interfaces;
    using RefMan.Services;
    using RefMan.Services.Interfaces;
    using RefMan.ViewModels;
    using RefMan.ViewModels.Interfaces;

    internal class AppBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        internal AppBootstrapper()
        {
            Initialize();
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void Configure()
        {
            // Register Factories
            _container.Singleton<IFileSystemFactory, FileSystemFactory>();
            _container.Singleton<IReferenceFactory, ReferenceFactory>();

            // Register Services
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<IWindowManager, WindowManager>();

            _container.Singleton<IAppDataService, AppDataService>();
            _container.Singleton<IClipboardService, ClipboardService>();
            _container.Singleton<IDataService, DataService>();
            _container.Singleton<IFileSystemService, FileSystemService>();
            _container.Singleton<IReferencingService, ReferencingService>();
            _container.Singleton<ISettingsService, SettingsService>();
            _container.Singleton<IWebService, WebService>();

            // Register ViewModels
            _container.Singleton<IShellViewModel, ShellViewModel>();
            _container.Singleton<IMainViewModel, MainViewModel>();

            _container.Singleton<IFileSystemViewModel, FileSystemViewModel>();

            _container.PerRequest<IFolderViewModel, FolderViewModel>();
            _container.PerRequest<IFileViewModel, FileViewModel>();

            _container.Singleton<IReferenceGeneratorViewModel, ReferenceGeneratorViewModel>();

            _container.Singleton<IReferencesViewModel, ReferencesViewModel>();

            _container.PerRequest<IReferenceViewModel, ReferenceViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }
    }
}
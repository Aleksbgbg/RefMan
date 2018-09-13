﻿namespace RefMan
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

            // Register Services
            _container.Singleton<IWindowManager, WindowManager>();

            _container.Singleton<IFileSystemService, FileSystemService>();

            // Register ViewModels
            _container.Singleton<IShellViewModel, ShellViewModel>();
            _container.Singleton<IMainViewModel, MainViewModel>();
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
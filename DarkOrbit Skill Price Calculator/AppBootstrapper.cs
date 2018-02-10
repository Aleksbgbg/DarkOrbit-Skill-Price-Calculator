namespace DarkOrbitSkillPriceCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using DarkOrbitSkillPriceCalculator.Factories;
    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
    using DarkOrbitSkillPriceCalculator.ViewModels;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

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
            // Register Services
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IInputFactory, InputFactory>();

            // Register ViewModels
            _container.Singleton<IShellViewModel, ShellViewModel>();
            _container.Singleton<IMainViewModel, MainViewModel>();
            _container.PerRequest<IInputFormViewModel, InputFormViewModel>();
            _container.PerRequest<IInputUpdateButtonViewModel, InputUpdateButtonViewModel>();
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
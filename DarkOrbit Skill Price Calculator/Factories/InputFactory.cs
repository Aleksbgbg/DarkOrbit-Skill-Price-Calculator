namespace DarkOrbitSkillPriceCalculator.Factories
{
    using System;

    using Caliburn.Micro;

    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class InputFactory : IInputFactory
    {
        public IInputFormViewModel MakeInputForm(string description, int minValue, int increment, int maxValue, Action<SkillStats, int> statTransformer)
        {
            IInputFormViewModel inputFormViewModel = IoC.Get<IInputFormViewModel>();
            inputFormViewModel.Initialise(description, minValue, increment, maxValue, statTransformer);

            return inputFormViewModel;
        }

        public IInputUpdateButtonViewModel MakeInputUpdateButton(InputUpdateButton inputUpdateButton)
        {
            IInputUpdateButtonViewModel inputUpdateButtonViewModel = IoC.Get<IInputUpdateButtonViewModel>();
            inputUpdateButtonViewModel.Initialise(inputUpdateButton);

            return inputUpdateButtonViewModel;
        }

        public IOutputViewModel MakeOutput(Output output)
        {
            IOutputViewModel outputViewModel = IoC.Get<IOutputViewModel>();
            outputViewModel.Initialise(output);

            return outputViewModel;
        }
    }
}
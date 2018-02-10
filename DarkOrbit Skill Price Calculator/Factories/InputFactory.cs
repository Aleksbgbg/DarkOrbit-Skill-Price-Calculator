namespace DarkOrbitSkillPriceCalculator.Factories
{
    using Caliburn.Micro;

    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class InputFactory : IInputFactory
    {
        public IInputFormViewModel MakeInputForm(string description, int minValue, int increment, int maxValue)
        {
            IInputFormViewModel inputFormViewModel = IoC.Get<IInputFormViewModel>();
            inputFormViewModel.Initialise(description, minValue, increment, maxValue);

            return inputFormViewModel;
        }

        public IInputUpdateButtonViewModel MakeInputUpdateButton(InputUpdateButton inputUpdateButton)
        {
            IInputUpdateButtonViewModel inputUpdateButtonViewModel = IoC.Get<IInputUpdateButtonViewModel>();
            inputUpdateButtonViewModel.Initialise(inputUpdateButton);

            return inputUpdateButtonViewModel;
        }
    }
}
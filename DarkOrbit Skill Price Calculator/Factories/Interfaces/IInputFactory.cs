namespace DarkOrbitSkillPriceCalculator.Factories.Interfaces
{
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal interface IInputFactory
    {
        IInputFormViewModel MakeInputForm(string description, int minValue, int increment, int maxValue);

        IInputUpdateButtonViewModel MakeInputUpdateButton(InputUpdateButton inputUpdateButton);
    }
}
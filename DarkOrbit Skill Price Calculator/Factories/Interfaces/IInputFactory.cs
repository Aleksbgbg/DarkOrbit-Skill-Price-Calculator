namespace DarkOrbitSkillPriceCalculator.Factories.Interfaces
{
    using System;

    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal interface IInputFactory
    {
        IInputFormViewModel MakeInputForm(string description, int minValue, int increment, int maxValue, Action<SkillStats, int> statTransformer);

        IInputUpdateButtonViewModel MakeInputUpdateButton(InputUpdateButton inputUpdateButton);

        IOutputViewModel MakeOutput(Output output);
    }
}
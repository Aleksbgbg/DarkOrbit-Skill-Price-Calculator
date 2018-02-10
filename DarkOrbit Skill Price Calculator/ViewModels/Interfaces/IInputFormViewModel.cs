namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    using System;

    using DarkOrbitSkillPriceCalculator.Models;

    internal interface IInputFormViewModel : IViewModelBase
    {
        InputForm InputForm { get; }

        void Initialise(string description, int minValue, int defaultValue, int increment, int maxValue, Action<SkillStats, int> statTransformer);
    }
}
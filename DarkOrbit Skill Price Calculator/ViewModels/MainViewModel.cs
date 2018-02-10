namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IInputFactory inputFactory)
        {
            IEnumerable<IInputFormViewModel> GetInputForms()
            {
                string[] descriptions = { "Enter Current Skill Points:", "Enter Required Skill Points:", "Enter Current Logdisks:" };
                int[] minValues = { 0, 1, 0 };
                int[] increments = { 5, 5, 25 };
                int[] maxValues = { 49, 50, 9_999_999 };
                Action<SkillStats, int>[] actions =
                {
                        (stats, currentValue) => stats.InitialResearchPoint = currentValue,
                        (stats, currentValue) => stats.FinalResearchPoint = currentValue,
                        (stats, currentValue) => stats.LogdiskCount = currentValue
                };

                for (int index = 0; index < 3; ++index)
                {
                    yield return inputFactory.MakeInputForm(descriptions[index], minValues[index], increments[index], maxValues[index], actions[index]);
                }
            }

            InputForms = GetInputForms().ToArray();
            Outputs = new Output[]
            {
                    new Output(value => value, value => "Logdisk"),
                    new Output(value => value * 100, value =>
                    {
                        if (value < 10_000) return "One Coin";

                        if (value < 100_000) return "Two Coins";

                        return "Three Coins";
                    })

            }.Select(output => inputFactory.MakeOutput(output )).ToArray();
        }

        public IInputFormViewModel[] InputForms { get; }

        public IOutputViewModel[] Outputs { get; }
    }
}
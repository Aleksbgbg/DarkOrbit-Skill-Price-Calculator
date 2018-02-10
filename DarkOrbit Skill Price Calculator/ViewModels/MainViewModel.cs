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
                string[] descriptions = { "Enter Current Skill Points:", "Enter Required Skill Points:", "Enter Current Logdisks:", "Enter Logdisk Price:" };
                int[] minValues = { 0, 1, 0, 0 };
                int[] defaultValues = { 0, 1, 0, 100 };
                int[] increments = { 5, 5, 25, 5 };
                int[] maxValues = { 49, 50, 9_999_999, 100 };
                Action<SkillStats, int>[] actions =
                {
                        (skillStats, currentValue) => skillStats.InitialResearchPoint = currentValue,
                        (skillStats, currentValue) => skillStats.FinalResearchPoint = currentValue,
                        (skillStats, currentValue) => skillStats.LogdiskCount = currentValue,
                        (skillStats, currentValue) => skillStats.LogdiskPrice = currentValue
                };

                for (int index = 0; index < 4; ++index)
                {
                    yield return inputFactory.MakeInputForm(descriptions[index], minValues[index], defaultValues[index],
                                                            increments[index], maxValues[index], actions[index]);
                }
            }

            InputForms = GetInputForms().ToArray();
            Outputs = new Output[]
            {
                    new Output(value => value, value => "Logdisk"),
                    new Output(value => value * SkillStats.Instance.LogdiskPrice, value =>
                    {
                        if (value < 10_000) return "One Coin";

                        if (value < 100_000) return "Two Coins";

                        return "Three Coins";
                    })

            }.Select(inputFactory.MakeOutput).ToArray();
        }

        public IInputFormViewModel[] InputForms { get; }

        public IOutputViewModel[] Outputs { get; }
    }
}
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
            SkillStats skillStats = new SkillStats();

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
                    yield return inputFactory.MakeInputForm(descriptions[index], minValues[index], increments[index], maxValues[index], skillStats, actions[index]);
                }
            }

            InputForms = GetInputForms().ToArray();
            Outputs = new Output[]
            {
                    new Output(value => value),
                    new Output(value => value * 100)

            }.Select(output => inputFactory.MakeOutput(output, skillStats)).ToArray();
        }

        public IInputFormViewModel[] InputForms { get; }

        public IOutputViewModel[] Outputs { get; }
    }
}
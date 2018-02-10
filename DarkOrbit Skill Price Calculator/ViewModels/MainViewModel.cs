namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
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

                for (int index = 0; index < 3; ++index)
                {
                    yield return inputFactory.MakeInputForm(descriptions[index], minValues[index], increments[index], maxValues[index]);
                }
            }

            InputForms = GetInputForms().ToArray();
        }

        public IInputFormViewModel[] InputForms { get; }
    }
}
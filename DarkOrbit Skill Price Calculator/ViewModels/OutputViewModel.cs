namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class OutputViewModel : ViewModelBase, IOutputViewModel
    {
        public Output Output { get; private set; }

        public void Initialise(Output output)
        {
            Output = output;

            void UpdateOutput()
            {
                Output.UpdateValue(SkillStats.Instance);
            }

            SkillStats.Instance.PropertyChanged += (sender, e) => UpdateOutput();
            UpdateOutput();
        }
    }
}
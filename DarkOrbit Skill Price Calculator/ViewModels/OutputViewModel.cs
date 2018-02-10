namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class OutputViewModel : ViewModelBase, IOutputViewModel
    {
        private SkillStats _skillStats;

        public Output Output { get; private set; }

        public void Initialise(Output output, SkillStats skillStats)
        {
            Output = output;
            _skillStats = skillStats;

            void UpdateOuptut()
            {
                Output.UpdateValue(_skillStats);
            }

            _skillStats.PropertyChanged += (sender, e) => UpdateOuptut();
            UpdateOuptut();
        }
    }
}
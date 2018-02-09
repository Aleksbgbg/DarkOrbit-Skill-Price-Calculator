namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal sealed class ShellViewModel : ViewModelBase, IShellViewModel
    {
        public ShellViewModel(IMainViewModel mainViewModel)
        {
            DisplayName = "DarkOrbit Skill Price Calculator";

            MainViewModel = mainViewModel;
        }

        public IMainViewModel MainViewModel { get; }
    }
}
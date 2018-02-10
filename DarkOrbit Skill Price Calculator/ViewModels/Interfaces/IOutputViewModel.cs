namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    using DarkOrbitSkillPriceCalculator.Models;

    internal interface IOutputViewModel : IViewModelBase
    {
        void Initialise(Output output);
    }
}
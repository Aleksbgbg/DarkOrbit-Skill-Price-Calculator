namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    using DarkOrbitSkillPriceCalculator.Models;

    internal interface IInputFormViewModel : IViewModelBase
    {
        void Initialise(string description, int minValue, int increment, int maxValue);
    }
}
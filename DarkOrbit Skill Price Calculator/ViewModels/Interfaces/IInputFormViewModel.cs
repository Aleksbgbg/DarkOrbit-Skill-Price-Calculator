namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    internal interface IInputFormViewModel : IViewModelBase
    {
        void Initialise(string description, int minValue, int increment, int maxValue);
    }
}
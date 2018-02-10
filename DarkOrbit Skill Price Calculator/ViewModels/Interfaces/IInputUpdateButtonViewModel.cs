namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    using System;

    using DarkOrbitSkillPriceCalculator.Models;

    internal interface IInputUpdateButtonViewModel : IViewModelBase
    {
        event EventHandler InputUpdated;

        InputUpdateButton InputUpdateButton { get; }

        void Initialise(InputUpdateButton inputUpdateButton);
    }
}
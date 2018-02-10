namespace DarkOrbitSkillPriceCalculator.ViewModels.Interfaces
{
    using System;

    using DarkOrbitSkillPriceCalculator.EventArgs;
    using DarkOrbitSkillPriceCalculator.Models;

    internal interface IInputUpdateButtonViewModel : IViewModelBase
    {
        event EventHandler<InputUpdateEventArgs> InputUpdated;

        InputUpdateButton InputUpdateButton { get; }

        void Initialise(InputUpdateButton inputUpdateButton);
    }
}
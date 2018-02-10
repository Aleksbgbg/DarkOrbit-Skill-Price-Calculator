namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using System;

    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class InputUpdateButtonViewModel : ViewModelBase, IInputUpdateButtonViewModel
    {
        public event EventHandler InputUpdated;

        public InputUpdateButton InputUpdateButton { get; private set; }

        public void UpdateInput()
        {
            InputUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void Initialise(InputUpdateButton inputUpdateButton)
        {
            InputUpdateButton = inputUpdateButton;
        }
    }
}
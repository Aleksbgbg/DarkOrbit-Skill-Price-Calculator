namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using System;

    using DarkOrbitSkillPriceCalculator.EventArgs;
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class InputUpdateButtonViewModel : ViewModelBase, IInputUpdateButtonViewModel
    {
        public event EventHandler<InputUpdateEventArgs> InputUpdated;

        public InputUpdateButton InputUpdateButton { get; private set; }

        public void UpdateInput()
        {
            InputUpdated?.Invoke(this, new InputUpdateEventArgs(InputUpdateButton.Action));
        }

        public void Initialise(InputUpdateButton inputUpdateButton)
        {
            InputUpdateButton = inputUpdateButton;
        }
    }
}
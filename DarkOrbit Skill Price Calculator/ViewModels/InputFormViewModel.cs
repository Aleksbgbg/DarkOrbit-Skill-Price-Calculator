﻿namespace DarkOrbitSkillPriceCalculator.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using DarkOrbitSkillPriceCalculator.Factories.Interfaces;
    using DarkOrbitSkillPriceCalculator.Models;
    using DarkOrbitSkillPriceCalculator.ViewModels.Interfaces;

    internal class InputFormViewModel : ViewModelBase, IInputFormViewModel
    {
        private readonly IInputFactory _inputFactory;

        public InputFormViewModel(IInputFactory inputFactory)
        {
            _inputFactory = inputFactory;
        }

        public InputForm InputForm { get; private set; }

        public IInputUpdateButtonViewModel[] InputUpdateButtons { get; private set; }

        public void Initialise(string description, int minValue, int increment, int maxValue)
        {
            InputForm = new InputForm(description, minValue, maxValue);

            IEnumerable<IInputUpdateButtonViewModel> GetInputUpdateButtons()
            {
                foreach (IInputUpdateButtonViewModel inputUpdateButtonViewModel in new InputUpdateButton[]
                {
                        new InputUpdateButton($"{minValue:N0}", value => minValue),
                        new InputUpdateButton($"-{increment}", value => value - increment),
                        new InputUpdateButton($"+{increment}", value => value + increment),
                        new InputUpdateButton($"{maxValue:N0}", value => maxValue)
                }.Select(_inputFactory.MakeInputUpdateButton))
                {
                    inputUpdateButtonViewModel.InputUpdated += (sender, e) => InputForm.UpdateValue(e.NewValuePredicate);

                    yield return inputUpdateButtonViewModel;
                }
            }

            InputUpdateButtons = GetInputUpdateButtons().ToArray();
        }
    }
}
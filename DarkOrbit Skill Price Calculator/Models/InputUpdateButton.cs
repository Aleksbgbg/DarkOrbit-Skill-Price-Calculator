namespace DarkOrbitSkillPriceCalculator.Models
{
    using System;

    internal class InputUpdateButton
    {
        internal InputUpdateButton(string text, Func<int, int> action)
        {
            Text = text;
            Action = action;
        }

        public string Text { get; }

        public Func<int, int> Action { get; }
    }
}
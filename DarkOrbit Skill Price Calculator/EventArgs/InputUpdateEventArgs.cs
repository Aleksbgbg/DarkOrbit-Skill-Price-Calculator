namespace DarkOrbitSkillPriceCalculator.EventArgs
{
    using System;

    internal class InputUpdateEventArgs : EventArgs
    {
        internal InputUpdateEventArgs(Func<int, int> newValuePredicate)
        {
            NewValuePredicate = newValuePredicate;
        }

        public Func<int, int> NewValuePredicate { get; }
    }
}
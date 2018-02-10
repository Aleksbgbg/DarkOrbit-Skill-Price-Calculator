namespace DarkOrbitSkillPriceCalculator.EventArgs
{
    using System;

    internal class InputUpdateEventArgs : EventArgs
    {
        internal InputUpdateEventArgs(Func<int, int> newValueConversionMethod)
        {
            NewValueConversionMethod = newValueConversionMethod;
        }

        public Func<int, int> NewValueConversionMethod { get; }
    }
}
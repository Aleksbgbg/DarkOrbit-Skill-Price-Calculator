namespace DarkOrbitSkillPriceCalculator.Models
{
    using System;

    using Caliburn.Micro;

    internal class Output : PropertyChangedBase
    {
        private readonly Func<int, int> _valueUpdateMethod;

        internal Output(Func<int, int> valueUpdateMethod)
        {
            _valueUpdateMethod = valueUpdateMethod;
        }

        private int _value;
        public int Value
        {
            get => _value;

            set
            {
                if (_value == value) return;

                _value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }

        internal void UpdateValue(SkillStats skillStats)
        {
            Value = _valueUpdateMethod(ComputeLogdisks(skillStats.InitialResearchPoint, skillStats.FinalResearchPoint) - skillStats.LogdiskCount);
        }

        private static int ComputeLogdisks(int initialResearchPoint, int finalResearchPoint)
        {
            int ComputeTotalLogdisks(int researchPoint)
            {
                return (int)Math.Round(Math.Pow(1.1, researchPoint) / 0.1 * 30, 0, MidpointRounding.AwayFromZero);
            }

            return ComputeTotalLogdisks(finalResearchPoint) - ComputeTotalLogdisks(initialResearchPoint);
        }
    }
}
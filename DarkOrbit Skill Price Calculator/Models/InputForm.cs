namespace DarkOrbitSkillPriceCalculator.Models
{
    using System;

    using Caliburn.Micro;

    internal class InputForm : PropertyChangedBase
    {
        private readonly Action<SkillStats, int> _statTransformer;

        internal InputForm(string description, int minValue, int maxValue, Action<SkillStats, int> statTransformer)
        {
            _statTransformer = statTransformer;

            Description = description;
            MinValue = minValue;
            MaxValue = maxValue; // Must occur before Value is set, in order to perform accurate validation
            Value = minValue;
        }

        public string Description { get; }

        public int MinValue { get; }

        private int _value;
        public int Value
        {
            get => _value;

            set
            {
                if (_value == value) return;

                if (value < MinValue)
                {
                    _value = MinValue;
                }
                else if (MaxValue < value)
                {
                    _value = MaxValue;
                }
                else
                {
                    _value = value;
                }

                NotifyOfPropertyChange(() => Value);

                _statTransformer(SkillStats.Instance, _value);
            }
        }

        public int MaxValue { get; }

        internal void UpdateValue(Func<int, int> predicate)
        {
            Value = predicate(Value);
        }
    }
}
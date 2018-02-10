namespace DarkOrbitSkillPriceCalculator.Models
{
    using Caliburn.Micro;

    internal class SkillStats : PropertyChangedBase
    {
        public static SkillStats Instance { get; } = new SkillStats();

        private int _initialResearchPoint;
        public int InitialResearchPoint
        {
            get => _initialResearchPoint;

            set
            {
                if (_initialResearchPoint == value) return;

                _initialResearchPoint = value;
                NotifyOfPropertyChange(() => InitialResearchPoint);
            }
        }

        private int _finalResearchPoint;
        public int FinalResearchPoint
        {
            get => _finalResearchPoint;

            set
            {
                if (_finalResearchPoint == value) return;

                _finalResearchPoint = value;
                NotifyOfPropertyChange(() => FinalResearchPoint);
            }
        }

        private int _logdiskCount;
        public int LogdiskCount
        {
            get => _logdiskCount;

            set
            {
                if (_logdiskCount == value) return;

                _logdiskCount = value;
                NotifyOfPropertyChange(() => LogdiskCount);
            }
        }

        private int _logdiskPrice;
        public int LogdiskPrice
        {
            get => _logdiskPrice;

            set
            {
                if (_logdiskPrice == value) return;

                _logdiskPrice = value;
                NotifyOfPropertyChange(() => LogdiskPrice);
            }
        }
    }
}
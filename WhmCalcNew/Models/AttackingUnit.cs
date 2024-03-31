namespace WhmCalcNew.Models
{
    public class AttackingUnit : ObservableObject
    {
        #region Свойства
        private string? _attacks;
        public string? Attacks
        {
            get => _attacks;
            set
            {
                _attacks = value;
                OnPropertyChanged();
            }
        }

        private byte? _accuracy;
        public byte? Accuracy
        {
            get => _accuracy;
            set
            {
                _accuracy = value;
                OnPropertyChanged();
            }
        }

        private byte? _strength;
        public byte? Strength
        {
            get => _strength;
            set
            {
                _strength = value;
                OnPropertyChanged();
            }
        }

        private byte? _armorPen;
        public byte? ArmorPen
        {
            get => _armorPen;
            set
            {
                _armorPen = value;
                OnPropertyChanged();
            }
        }

        private string? _damage;
        public string? Damage
        {
            get => _damage;
            set
            {
                _damage = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public AttackingUnit()
        {
            Attacks = 0.ToString();
            Accuracy = 1;
            Strength = 2;
            ArmorPen = 3;
            Damage = 4.ToString();
        }
    }
}

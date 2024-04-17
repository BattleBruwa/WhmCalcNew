namespace WhmCalcNew.Models
{
    public class AttackingUnit : ObservableObject
    {
        #region Свойства

        // Количество атак
        private string? _attacks;
        public string? Attacks
        {
            get { return _attacks; }
            set
            {
                _attacks = value;
                OnPropertyChanged();
            }
        }

        // WS/BS меткость атак
        private byte? _accuracy;
        public byte? Accuracy
        {
            get { return _accuracy; }
            set
            {
                _accuracy = value;
                OnPropertyChanged();
            }
        }

        // Сила атаки
        private byte? _strength;
        public byte? Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                OnPropertyChanged();
            }
        }

        // Пробивание защиты
        private byte? _armorPen;
        public byte? ArmorPen
        {
            get { return _armorPen; }
            set
            {
                _armorPen = value;
                OnPropertyChanged();
            }
        }

        // Урон атаки
        private string? _damage;
        public string? Damage
        {
            get { return _damage; }
            set
            {
                _damage = value;
                OnPropertyChanged();
            }
        }

        // Рерол единиц на хит
        private bool _hasRerollToHit1;
        public bool HasRerollToHit1
        {
            get { return _hasRerollToHit1; }
            set
            {
                _hasRerollToHit1 = value;
                OnPropertyChanged();
            }
        }

        // Рерол единиц на вунд
        private bool _hasRerollToWound1;
        public bool HasRerollToWound1
        {
            get { return _hasRerollToWound1; }
            set
            {
                _hasRerollToWound1 = value;
                OnPropertyChanged();
            }
        }

        // Рерол хитов
        private bool _hasRerollToHitAll;
        public bool HasRerollToHitAll
        {
            get { return _hasRerollToHitAll; }
            set
            {
                _hasRerollToHitAll = value;
                OnPropertyChanged();
            }
        }

        // Рерол вундов
        private bool _hasRerollToWoundAll;
        public bool HasRerollToWoundAll
        {
            get { return _hasRerollToWoundAll; }
            set
            {
                _hasRerollToWoundAll = value;
                OnPropertyChanged();
            }
        }

        // Минус 1 на вунд
        private bool _isMinusOneToWound;
        public bool IsMinusOneToWound
        {
            get { return _isMinusOneToWound; }
            set { _isMinusOneToWound = value; }
        }


        // Литалки
        private bool _hasLethalHits;
        public bool HasLethalHits
        {
            get { return _hasLethalHits; }
            set
            {
                _hasLethalHits = value;
                OnPropertyChanged();
            }
        }

        // Sustained!
        private bool _hasSustainedHits;
        public bool HasSustainedHits
        {
            get { return _hasSustainedHits; }
            set
            {
                _hasSustainedHits = value;
                OnPropertyChanged();
            }
        }

        // Криты на 5
        private bool _hasCritsOn5s;
        public bool HasCritsOn5s
        {
            get { return _hasCritsOn5s; }
            set
            {
                _hasCritsOn5s = value;
                OnPropertyChanged();
            }
        }

        // Дев вундс
        private bool _hasDevastatingWounds;
        public bool HasDevastatingWounds
        {
            get { return _hasDevastatingWounds; }
            set
            {
                _hasDevastatingWounds = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public AttackingUnit()
        {
            HasRerollToHit1 = false;
            HasRerollToHitAll = false;
            HasRerollToWound1 = false;
            HasRerollToWoundAll = false;
            HasSustainedHits = false;
            HasLethalHits = false;
            HasCritsOn5s = false;
            HasDevastatingWounds = false;
        }
    }
}

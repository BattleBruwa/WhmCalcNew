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

        //private bool _hasRerollToHit1;
        //public bool HasRerollToHit1
        //{
        //    get { return _hasRerollToHit1; }
        //    set
        //    { 
        //        _hasRerollToHit1 = value; 
        //        OnPropertyChanged();
        //    }
        //}

        //private bool _hasRerollToWound1;
        //public bool HasRerollToWound1
        //{
        //    get { return _hasRerollToWound1; }
        //    set
        //    {
        //        _hasRerollToWound1 = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private bool _hasRerollToHitAll;
        //public bool HasRerollToHitAll
        //{
        //    get { return _hasRerollToHitAll; }
        //    set
        //    {
        //        _hasRerollToHitAll = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private bool _hasRerollToWoundAll;
        //public bool HasRerollToWoundAll
        //{
        //    get { return _hasRerollToWoundAll; }
        //    set
        //    {
        //        _hasRerollToWoundAll = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private LethalHits _hasLethalHits;

        //public LethalHits HasLethalHits
        //{
        //    get { return _hasLethalHits; }
        //    set {  }
        //}


        #endregion

        //#region Енумы для свойств
        //private enum LethalHits
        //{
        //    False,
        //    OnSixes,
        //    OnFives
        //}

        //private enum DevastatingWounds
        //{
        //    False,
        //    OnSixes,
        //    OnFives,
        //    OnFours,
        //    OnThrees,
        //    OnTwos
        //}
        //#endregion
    }
}

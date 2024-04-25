using System.Runtime.CompilerServices;
using WhmCalcNew.ViewModel;

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
        private bool _hasRerollToHit1 = false;
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
        private bool _hasRerollToWound1 = false;
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
        private bool _hasRerollToHitAll = false;
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
        private bool _hasRerollToWoundAll = false;
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
        private bool _isMinusOneToWound = false;
        public bool IsMinusOneToWound
        {
            get { return _isMinusOneToWound; }
            set
            {
                _isMinusOneToWound = value;
                OnPropertyChanged();
            }
        }


        // Литалки
        private bool _hasLethalHits = false;
        public bool HasLethalHits
        {
            get { return _hasLethalHits; }
            set
            {
                if (value == true)
                {
                    _hasLethalHits = value;
                }
                else
                {
                    LethalHitsNum = null;
                    _hasLethalHits = value;
                }
                OnPropertyChanged();
            }
        }

        // Количесвто литалок
        private float? _lethalHitsNum;
        public float? LethalHitsNum
        {
            get { return _lethalHitsNum; }
            set
            {
                if (value != null)
                {
                    _lethalHitsNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _lethalHitsNum = null;
                }
            }
        }

        // Sustained!
        private bool _hasSustainedHits = false;
        public bool HasSustainedHits
        {
            get { return _hasSustainedHits; }
            set
            {
                if (value == true)
                {
                    _hasSustainedHits = value;
                }
                else
                {
                    SustainedHitsNum = null;
                    _hasSustainedHits = value;
                }
                OnPropertyChanged();
            }
        }

        // Количество доп хитов от sustained
        private float? _sustainedHitsNum;
        public float? SustainedHitsNum
        {
            get { return _sustainedHitsNum; }
            set
            {
                if (value != null)
                {
                    _sustainedHitsNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _sustainedHitsNum = null;
                }
            }
        }

        // Криты на 5
        private bool _hasCritsOn5s = false;
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
        private bool _hasDevastatingWounds = false;
        public bool HasDevastatingWounds
        {
            get { return _hasDevastatingWounds; }
            set
            {
                if (value == true)
                {
                    _hasDevastatingWounds = value;
                }
                else
                {
                    DevastatingWoundsNum = null;
                    _hasDevastatingWounds = value;
                }
                OnPropertyChanged();
            }
        }

        // Количесвто дев вунд
        private float? _devastatingWoundsNum;
        public float? DevastatingWoundsNum
        {
            get { return _devastatingWoundsNum; }
            set
            {
                if (value != null)
                {
                    _devastatingWoundsNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _devastatingWoundsNum = null;
                }
            }
        }
        #endregion

        public AttackingUnit()
        {

        }


    }
}

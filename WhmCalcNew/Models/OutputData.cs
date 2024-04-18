namespace WhmCalcNew.Models
{
    public class OutputData: ObservableObject
    {
        #region Свойства

        // частые приведения к double
        // сменить float на double во всех свойствах?


        private float? _attacksNum;
        public float? AttacksNum
        {
            get { return _attacksNum; }
            set
            {
                if (value != null)
                {
                    _attacksNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _attacksNum = null;
                }
                OnPropertyChanged();
            }
        }

        // Количесвто хитов
        private float? _hitsNum;
        public float? HitsNum
        {
            get { return _hitsNum; }
            set
            {
                if (value != null)
                {
                    _hitsNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _hitsNum = null;
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
                OnPropertyChanged();
            }
        }


        // Количесвто вундов
        private float? _woundsNum;
        public float? WoundsNum
        {
            get { return _woundsNum; }
            set
            {
                if (value != null)
                {
                    _woundsNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _woundsNum = null;
                }
                OnPropertyChanged();
            }
        }

        // Количество непрошедших защиту вундов
        private float? _unSavedNum;
        public float? UnSavedNum
        {
            get { return _unSavedNum; }
            set
            {
                if (value != null)
                {
                    _unSavedNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _unSavedNum = null;
                }
                OnPropertyChanged();
            }
        }

        // Количество уничтоженых моделей
        private int? _deadModelsNum;
        public int? DeadModelsNum
        {
            get { return _deadModelsNum; }
            set
            {
                _deadModelsNum = value;
                OnPropertyChanged();
            }
        }

        // Полный нанесенный урон
        private float? _totalDamageNum;
        public float? TotalDamageNum
        {
            get { return _totalDamageNum; }
            set
            {
                if (value != null)
                {
                    _totalDamageNum = (float)Math.Round((double)value, 2);
                }
                else
                {
                    _totalDamageNum = null;
                }
                OnPropertyChanged();
            }
        }
        #endregion

        public OutputData()
        {

            DevastatingWoundsNum = 0;
            LethalHitsNum = 0;
        }
    }
}

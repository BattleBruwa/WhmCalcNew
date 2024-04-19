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

        }
    }
}

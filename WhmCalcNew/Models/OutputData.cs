using MvvmHelpers;

namespace WhmCalcNew.Models
{
    public class OutputData: ObservableObject
    {
        #region Свойства
        private double _attacksNum;
        public double AttacksNum
        {
            get { return _attacksNum; }
            set
            {
                SetProperty(ref _attacksNum, Math.Round(value, 2));
            }
        }

        // Количесвто хитов
        private double _hitsNum;
        public double HitsNum
        {
            get { return _hitsNum; }
            set
            {;
                SetProperty(ref _hitsNum, Math.Round(value, 2));
            }
        }

        // Количесвто вундов
        private double _woundsNum;
        public double WoundsNum
        {
            get { return _woundsNum; }
            set
            {
                SetProperty(ref _woundsNum, Math.Round(value, 2));
            }
        }

        // Количество непрошедших защиту вундов
        private double _unSavedNum;
        public double UnSavedNum
        {
            get { return _unSavedNum; }
            set
            {
                SetProperty(ref _unSavedNum, Math.Round(value, 2));
            }
        }

        // Количество уничтоженых моделей
        private double _deadModelsNum;
        public double DeadModelsNum
        {
            get { return _deadModelsNum; }
            set
            {
                SetProperty(ref _deadModelsNum, Math.Round(value, 0));
            }
        }

        // Полный нанесенный урон
        private double _totalDamageNum;
        public double TotalDamageNum
        {
            get { return _totalDamageNum; }
            set
            {
                SetProperty(ref _totalDamageNum, Math.Round(value, 2));
            }
        }
        #endregion
    }
}

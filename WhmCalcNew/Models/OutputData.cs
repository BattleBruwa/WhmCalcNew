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
                SetProperty(ref _attacksNum, value);
            }
        }

        // Количесвто хитов
        private double _hitsNum;
        public double HitsNum
        {
            get { return _hitsNum; }
            set
            {
                SetProperty(ref _hitsNum, value);
            }
        }

        // Количесвто вундов
        private double _woundsNum;
        public double WoundsNum
        {
            get { return _woundsNum; }
            set
            {
                SetProperty(ref _woundsNum, value);
            }
        }

        // Количество непрошедших защиту вундов
        private double _unSavedNum;
        public double UnSavedNum
        {
            get { return _unSavedNum; }
            set
            {
                SetProperty(ref _unSavedNum, value);
            }
        }

        // Количество уничтоженых моделей
        private double _deadModelsNum;
        public double DeadModelsNum
        {
            get { return _deadModelsNum; }
            set
            {
                SetProperty(ref _deadModelsNum, value);
            }
        }

        // Полный нанесенный урон
        private double _totalDamageNum;
        public double TotalDamageNum
        {
            get { return _totalDamageNum; }
            set
            {
                SetProperty(ref _totalDamageNum, value);
            }
        }
        #endregion
    }
}

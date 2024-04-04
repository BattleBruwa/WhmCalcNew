using WhmCalcNew.Engine.Calculations;

namespace WhmCalcNew.Models
{
    // решить, нужен ли ObservableObject тут
    public class OutputDataManager : ObservableObject
    {
        #region Свойства
        
        // частые приведения к double
        // сменить float на double во всех свойствах?


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


        public OutputDataManager()
        {

        }

        #region Методы

        /// <summary>Устанавливает свойство количества хитов произведением количества атак на вероятность попадания каждой атаки.</summary>
        public void GetHits(AttackingUnit attacker, TargetUnit target)
        {
            float attacks = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            float hitProb = AccuracyCalc.ToHitRoll(attacker, target);

            this.HitsNum = attacks * hitProb;
        }

        /// <summary>Устанавливает свойство количества вундов произведением количества хитов на вероятность провундить каждой атакой.</summary>
        public void GetWounds(AttackingUnit attacker, TargetUnit target)
        {
            float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            this.WoundsNum = this.HitsNum * woundProb;
        }

        /// <summary>Устанавливает свойство количества непрошедших защиту вундов.</summary>
        public void GetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            float saveProp = ArmorSaveCalc.ToSaveRoll(attacker, target);

            this.UnSavedNum = this.WoundsNum - (saveProp * this.WoundsNum);
        }

        /// <summary>Устанавливает свойство количества уничтоженых моделей.</summary>
        public void GetDeadModels(AttackingUnit attacker, TargetUnit target)
        {
            float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            int? deadModels = 0;

            if (damage < target.Wounds)
            {
                for (int i = 1; i < this.UnSavedNum; i++)
                {
                    float c = damage;
                    while (c < target.Wounds && i < this.UnSavedNum)
                    {
                        i++;
                        c = c + damage;
                    }
                    if (c >= target.Wounds)
                    {
                        deadModels++;
                    }
                }

            }
            if (damage >= target.Wounds)
            {
                deadModels = (int?)this.UnSavedNum;
            }

            this.DeadModelsNum = deadModels;
        }

        /// <summary>Устанавливает свойство полного нанесенного урона. </summary>
        public void GetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            this.TotalDamageNum = TotalDamageCalc.GetTotalDamage(attacker, target);
        }
        #endregion
    }
}

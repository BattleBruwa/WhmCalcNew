using WhmCalcNew.Engine.Calculations;

namespace WhmCalcNew.Models
{
    public class OutputDataManager
    {
        public static OutputData _OutputData { get; set; } = new OutputData();

        public static OutputData GetOutputData()
        { 
            return _OutputData;
        }

        public OutputDataManager()
        {

        }

        #region Методы

        /// <summary>Устанавливает свойство количества хитов произведением количества атак на вероятность попадания каждой атаки и количество литалок.</summary>
        public static void GetHits(AttackingUnit attacker)
        {
            float attacks = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            float hitProb = AccuracyCalc.ToHitRoll(attacker);

            // Обработка правила Lethal Hits:
            if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == false)
            {
                _OutputData.LethalHitsNum = attacks / 6f;
            }
            if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == true)
            {
                _OutputData.LethalHitsNum = attacks / 5f;
            }

            // Обработка правила Sustained Hits:
            if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == false)
            {
                attacks = attacks + (float)Math.Round((attacks / 6f), 2);
            }
            if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == true)
            {
                attacks = attacks + (float)Math.Round((attacks / 5f), 2);
            }

            _OutputData.HitsNum = attacks * hitProb;
        }

        /// <summary>Устанавливает свойство количества вундов произведением количества хитов на вероятность провундить каждой атакой.</summary>
        public static void GetWounds(AttackingUnit attacker, TargetUnit target)
        {
            float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            if(attacker.HasDevastatingWounds == true)
            {
                _OutputData.DevastatingWoundsNum = _OutputData.HitsNum / 6f;
            }

            _OutputData.WoundsNum = (_OutputData.HitsNum * woundProb) + _OutputData.LethalHitsNum;
        }

        /// <summary>Устанавливает свойство количества непрошедших защиту вундов.</summary>
        public static void GetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            float saveProb = ArmorSaveCalc.ToSaveRoll(attacker, target);

            _OutputData.UnSavedNum = _OutputData.WoundsNum - ((saveProb * _OutputData.WoundsNum) + _OutputData.DevastatingWoundsNum);
        }

        /// <summary>Устанавливает свойство количества уничтоженых моделей.</summary>
        public static void GetDeadModels(AttackingUnit attacker, TargetUnit target)
        {
            float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            int? deadModels = 0;

            if (damage < target.Wounds)
            {
                for (int i = 1; i < _OutputData.UnSavedNum; i++)
                {
                    float c = damage;
                    while (c < target.Wounds && i < _OutputData.UnSavedNum)
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
                deadModels = (int?)_OutputData.UnSavedNum;
            }

            _OutputData.DeadModelsNum = deadModels;
        }

        /// <summary>Устанавливает свойство полного нанесенного урона. </summary>
        public static void GetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            _OutputData.TotalDamageNum = TotalDamageCalc.GetTotalDamage(attacker, target);
        }
        #endregion
    }
}

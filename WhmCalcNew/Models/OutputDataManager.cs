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
        /// <summary>
        /// Устанавливает свойство количества атак.
        /// </summary>
        public static void SetAttacks(AttackingUnit attacker)
        {
            _OutputData.AttacksNum = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
        }

        /// <summary>Устанавливает свойство количества хитов произведением количества атак на вероятность попадания каждой атаки и количество литалок.</summary>
        public static void SetHits(AttackingUnit attacker)
        {
            SetAttacks(attacker);

            // Вероятность попасть атакой:
            float hitProb = AccuracyCalc.ToHitRoll(attacker);

            // Обработка правила Lethal Hits:
            if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == false)
            {
                _OutputData.LethalHitsNum = _OutputData.AttacksNum / 6f;
            }
            if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == true)
            {
                _OutputData.LethalHitsNum = _OutputData.AttacksNum / 3f;
            }

            // Обработка правила Sustained Hits:
            if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == false)
            {
                _OutputData.SustainedHitsNum = _OutputData.AttacksNum / 6f;
            }
            if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == true)
            {
                _OutputData.SustainedHitsNum = _OutputData.AttacksNum / 3f;
            }

            // Заполнение свойства HitsNum:
            if (_OutputData.SustainedHitsNum == 0 || _OutputData.SustainedHitsNum == null)
            {
                _OutputData.HitsNum = _OutputData.AttacksNum * hitProb;
            }
            else
            {
                _OutputData.HitsNum = (_OutputData.AttacksNum * hitProb) + _OutputData.SustainedHitsNum;
            }
        }

        /// <summary>Устанавливает свойство количества вундов произведением количества хитов на вероятность провундить каждой атакой.</summary>
        public static void SetWounds(AttackingUnit attacker, TargetUnit target)
        {
            SetHits(attacker);

            // Вероятность провундить:
            float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            // Обработка правила Devastating Wounds:
            if(attacker.HasDevastatingWounds == true)
            {
                _OutputData.DevastatingWoundsNum = _OutputData.HitsNum / 6f;
            }

            // Заполнение свойсвта WoundsNum:
            // Если есть дев вунды, их надо вычесть из общего пула вундов:
            if (_OutputData.LethalHitsNum == 0 || _OutputData.LethalHitsNum == null)
            {
                if (_OutputData.DevastatingWoundsNum == null || _OutputData.DevastatingWoundsNum == 0)
                {
                    _OutputData.WoundsNum = _OutputData.HitsNum * woundProb;
                }
                else
                {
                    _OutputData.WoundsNum = (_OutputData.HitsNum * woundProb) - _OutputData.DevastatingWoundsNum;
                }
            }
            else
            {
                if (_OutputData.DevastatingWoundsNum == null || _OutputData.DevastatingWoundsNum == 0)
                {
                    _OutputData.WoundsNum = ((_OutputData.HitsNum - _OutputData.LethalHitsNum) * woundProb) + _OutputData.LethalHitsNum;
                }
                else
                {
                    _OutputData.WoundsNum = ((_OutputData.HitsNum - _OutputData.LethalHitsNum)* woundProb) + _OutputData.LethalHitsNum - _OutputData.DevastatingWoundsNum;
                }
            }
        }

        /// <summary>Устанавливает свойство количества непрошедших защиту вундов.</summary>
        public static void SetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            SetWounds(attacker, target);

            // Вероятность засейвить:
            float saveProb = ArmorSaveCalc.ToSaveRoll(attacker, target);

            // Заполнение свойства UnSavedNum:
            if (_OutputData.DevastatingWoundsNum == null || _OutputData.DevastatingWoundsNum == 0)
            {
                _OutputData.UnSavedNum = _OutputData.WoundsNum - (saveProb * _OutputData.WoundsNum);
            }
            else
            {
                _OutputData.UnSavedNum = _OutputData.WoundsNum - ((saveProb * _OutputData.WoundsNum) + _OutputData.DevastatingWoundsNum);
            }
        }

        /// <summary>Устанавливает свойство количества уничтоженых моделей.</summary>
        public static void SetDeadModels(AttackingUnit attacker, TargetUnit target)
        {
            SetUnsavedWounds(attacker, target);

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
        public static void SetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            SetUnsavedWounds(attacker, target);

            float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);

            // Заполнение свойства TotalDamageNum:
            _OutputData.TotalDamageNum = _OutputData.UnSavedNum * damage;
        }
        #endregion
    }
}

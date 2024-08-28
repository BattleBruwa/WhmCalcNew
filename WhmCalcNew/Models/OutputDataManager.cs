using WhmCalcNew.Services.Calculations;

namespace WhmCalcNew.Models
{
    [Obsolete]
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
            //SetAttacks(attacker);
            //// Вероятность попасть атакой:
            //float hitProb = AccuracyCalc.ToHitRoll(attacker);

            //// Обработка правила Lethal Hits:
            //if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == false)
            //{
            //    attacker.LethalHitsNum = _OutputData.AttacksNum / 6f;
            //}
            //if (attacker.HasLethalHits == true && attacker.HasCritsOn5s == true)
            //{
            //    attacker.LethalHitsNum = _OutputData.AttacksNum / 3f;
            //}

            //// Обработка правила Sustained Hits:
            //if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == false)
            //{
            //    attacker.SustainedHitsNum = _OutputData.AttacksNum / 6f;
            //}
            //if (attacker.HasSustainedHits == true && attacker.HasCritsOn5s == true)
            //{
            //    attacker.SustainedHitsNum = _OutputData.AttacksNum / 3f;
            //}

            //// Заполнение свойства HitsNum:
            //if (attacker.SustainedHitsNum == 0 || attacker.SustainedHitsNum == null)
            //{
            //    _OutputData.HitsNum = _OutputData.AttacksNum * hitProb;
            //}
            //else
            //{
            //    _OutputData.HitsNum = (_OutputData.AttacksNum * hitProb) + attacker.SustainedHitsNum;
            //}
        }

        /// <summary>Устанавливает свойство количества вундов произведением количества хитов на вероятность провундить каждой атакой.</summary>
        public static void SetWounds(AttackingUnit attacker, TargetUnit target)
        {
            //SetHits(attacker);
            //// Вероятность провундить:
            //float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            //// Обработка правила Devastating Wounds:
            //if(attacker.HasDevastatingWounds == true)
            //{
            //    attacker.DevastatingWoundsNum = _OutputData.HitsNum / 6f;
            //}

            //// Заполнение свойсвта WoundsNum:
            //// Если есть дев вунды, их надо вычесть из общего пула вундов:
            //if (attacker.HasLethalHits == false)
            //{
            //    if (attacker.HasDevastatingWounds == false)
            //    {
            //        _OutputData.WoundsNum = _OutputData.HitsNum * woundProb;
            //    }
            //    if (attacker.HasDevastatingWounds == true)
            //    {
            //        _OutputData.WoundsNum = (_OutputData.HitsNum * woundProb) - attacker.DevastatingWoundsNum;
            //    }
            //}
            //if (attacker.HasLethalHits == true)
            //{
            //    if (attacker.HasDevastatingWounds == false)
            //    {
            //        _OutputData.WoundsNum = ((_OutputData.HitsNum - attacker.LethalHitsNum) * woundProb) + attacker.LethalHitsNum;
            //    }
            //    if (attacker.HasDevastatingWounds == true)
            //    {
            //        _OutputData.WoundsNum = ((_OutputData.HitsNum - attacker.LethalHitsNum) * woundProb) + attacker.LethalHitsNum - attacker.DevastatingWoundsNum;
            //    }
            //}
        }

        /// <summary>Устанавливает свойство количества непрошедших защиту вундов.</summary>
        public static void SetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            //SetWounds(attacker, target);
            //// Вероятность засейвить:
            //float saveProb = ArmorSaveCalc.ToSaveRoll(attacker, target);

            //// Заполнение свойства UnSavedNum:
            //if (attacker.HasDevastatingWounds == false)
            //{
            //    _OutputData.UnSavedNum = _OutputData.WoundsNum - (saveProb * _OutputData.WoundsNum);
            //}
            //else
            //{
            //    _OutputData.UnSavedNum = _OutputData.WoundsNum - ((saveProb * _OutputData.WoundsNum) + attacker.DevastatingWoundsNum);
            //}
        }

        /// <summary>Устанавливает свойство количества уничтоженых моделей.</summary>
        public static void SetDeadModels(AttackingUnit attacker, TargetUnit target)
        {
            //    SetUnsavedWounds(attacker, target);

            //    float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
            //    int? deadModels = 0;

            //    if (damage < target.Wounds)
            //    {
            //        for (int i = 1; i < _OutputData.UnSavedNum; i++)
            //        {
            //            float c = damage;
            //            while (c < target.Wounds && i < _OutputData.UnSavedNum)
            //            {
            //                i++;
            //                c = c + damage;
            //            }
            //            if (c >= target.Wounds)
            //            {
            //                deadModels++;
            //            }
            //        }

            //    }
            //    if (damage >= target.Wounds)
            //    {
            //        deadModels = (int?)_OutputData.UnSavedNum;
            //    }

            //    _OutputData.DeadModelsNum = deadModels;
        }

        /// <summary>Устанавливает свойство полного нанесенного урона. </summary>
        public static void SetTotalDamage(AttackingUnit attacker, TargetUnit target)
        {
            //SetUnsavedWounds(attacker, target);
            //float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);

            //// Заполнение свойства TotalDamageNum:
            //_OutputData.TotalDamageNum = _OutputData.UnSavedNum * damage;
        }
        #endregion
    }
}

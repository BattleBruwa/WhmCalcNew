using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmCalcNew.Engine;

namespace WhmCalcNew.Models
{
    public class OutputData
    {
        public float? HitsNum { get; set; }
        public float? WoundsNum { get; set; }
        public float? UnSavedNum { get; set; }
        public float? DeadModelsNum { get; set; }
        public float? TotalDamageNum { get; set; }

        public void GetHits(AttackingUnit attacker, TargetUnit target)
        {
            float attacks = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            float hitProb = AccuracyCalc.ToHitRoll(attacker, target);

            HitsNum = attacks * hitProb;
        }

        public void GetWounds(AttackingUnit attacker, TargetUnit target)
        {
            float woundProb = ToWoundCalc.ToWoundRoll(attacker, target);

            WoundsNum = HitsNum * woundProb;
        }

        public void GetUnsavedWounds(AttackingUnit attacker, TargetUnit target)
        {
            float saveProp = ArmorSaveCalc.ToSaveRoll(attacker, target);

            UnSavedNum = WoundsNum - (saveProp * WoundsNum);
        }

        //public void GetDeadModels(AttackingUnit attacker, TargetUnit target)
        //{
        //    float damagePerWound = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);
        //    int deadModels = 0;

        //    for (int i = 0; i < UnSavedNum; i++)
        //    {
        //        while (target.Wounds/damagePerWound >= 1)
        //        {

        //        }
        //    }
        //}
    }
}

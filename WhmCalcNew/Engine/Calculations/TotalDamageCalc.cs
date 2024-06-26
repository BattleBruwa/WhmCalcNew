﻿using WhmCalcNew.Models;

namespace WhmCalcNew.Engine.Calculations
{
    public static class TotalDamageCalc
    {
        public static float GetTotalDamage(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null)
            {
                return 0f;
            }
            float attacks = AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            float accuracy = AccuracyCalc.ToHitRoll(attacker);
            float wounds = ToWoundCalc.ToWoundRoll(attacker, target);
            float save = ArmorSaveCalc.ToSaveRoll(attacker, target);
            float damage = AttacksOrDamageCalc.CalculateAorD(attacker.Damage);

            float result = (attacks * accuracy * wounds - attacks * accuracy * wounds * save) * damage;

            return result;
        }
    }
}

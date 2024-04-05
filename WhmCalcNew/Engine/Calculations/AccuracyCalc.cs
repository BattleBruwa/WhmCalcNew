﻿using WhmCalcNew.Models;

namespace WhmCalcNew.Engine.Calculations
{
    public static class AccuracyCalc
    {
        /// <summary>
        /// Расчитывает вероятность попасть атакой по цели.
        /// </summary>
        public static float ToHitRoll(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null || attacker.Accuracy == null)
            {
                return 0f;
            }
            if (attacker.Accuracy == 0)
            {
                return 1;
            }
            if (target.IsHardToHit == true)
            {
                attacker.Accuracy = (byte)(attacker.Accuracy - 1);
            }

            return DiceRoller.RollTheDice((byte)attacker.Accuracy);
        }
    }
}

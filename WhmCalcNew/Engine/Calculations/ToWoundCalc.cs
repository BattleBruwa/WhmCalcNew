using WhmCalcNew.Models;

namespace WhmCalcNew.Engine.Calculations
{
    public static class ToWoundCalc
    {
        public static float ToWoundRoll(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null || attacker.Strength == null || target.Thoughness == null)
            {
                return 0f;
            }

            byte resultedRoll = 0;

            if (attacker.Strength == target.Thoughness)
            {
                resultedRoll = 4;
            }
            if (attacker.Strength > target.Thoughness && attacker.Strength < target.Thoughness * 2)
            {
                resultedRoll = 3;
            }
            if (attacker.Strength >= target.Thoughness * 2)
            {
                resultedRoll = 2;
            }
            if (attacker.Strength < target.Thoughness && attacker.Strength * 2 > target.Thoughness)
            {
                resultedRoll = 5;
            }
            if (attacker.Strength * 2 <= target.Thoughness)
            {
                resultedRoll = 6;
            }

            if (target.IsHardToWound == true)
            {
                return DiceRoller.RollTheDice(resultedRoll - 1);
            }
            else
            {
                return DiceRoller.RollTheDice(resultedRoll);
            }
        }
    }
}

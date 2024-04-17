using WhmCalcNew.Models;

namespace WhmCalcNew.Engine.Calculations
{
    public static class ToWoundCalc
    {
        /// <summary>
        /// Расчитывает вунд ролл.
        /// </summary>
        public static float ToWoundRoll(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null || attacker.Strength == null || target.Toughness == null)
            {
                return 0f;
            }

            byte resultedRoll = 0;

            if (attacker.Strength == target.Toughness)
            {
                resultedRoll = 4;
            }
            if (attacker.Strength > target.Toughness && attacker.Strength < target.Toughness * 2)
            {
                resultedRoll = 3;
            }
            if (attacker.Strength >= target.Toughness * 2)
            {
                resultedRoll = 2;
            }
            if (attacker.Strength < target.Toughness && attacker.Strength * 2 > target.Toughness)
            {
                resultedRoll = 5;
            }
            if (attacker.Strength * 2 <= target.Toughness)
            {
                resultedRoll = 6;
            }

            if (attacker.IsMinusOneToWound == true)
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

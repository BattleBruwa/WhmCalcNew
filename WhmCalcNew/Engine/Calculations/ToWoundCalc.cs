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


            if (attacker.HasRerollToWound1 == false && attacker.HasRerollToWoundAll == false)
            {
                if (attacker.IsMinusOneToWound == true)
                {
                    return DiceRoller.RollTheDice(resultedRoll + 1);
                }
                else if (attacker.IsMinusOneToWound == false)
                {
                    return DiceRoller.RollTheDice(resultedRoll);
                }
            }
            else
            {
                if (attacker.HasRerollToWound1 == true)
                {
                    // Минус 1 ту вунд
                    if (attacker.IsMinusOneToWound == true)
                    {
                        return DiceRoller.RollTheDiceWithReroll1s(resultedRoll + 1);
                    }
                    else if (attacker.IsMinusOneToWound == false)
                    {
                        return DiceRoller.RollTheDiceWithReroll1s(resultedRoll);
                    }
                }

                if (attacker.HasRerollToWoundAll == true)
                {
                    // Минус 1 ту вунд
                    if (attacker.IsMinusOneToWound == true)
                    {
                        return DiceRoller.RollTheDiceWithReroll(resultedRoll + 1);
                    }
                    else if (attacker.IsMinusOneToWound == false)
                    {
                        return DiceRoller.RollTheDiceWithReroll(resultedRoll);
                    }
                } 
            }

            return DiceRoller.RollTheDice(resultedRoll);
        }
    }
}

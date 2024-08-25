using System.Collections.ObjectModel;
using WhmCalcNew.Models;
using WhmCalcNew.Services.Calculations;

namespace WhmCalcNew.Engine.Calculations
{
    public static class ToWoundCalc
    {
        /// <summary>
        /// Расчитывает вунд ролл.
        /// </summary>
        public static float ToWoundRoll(AttackingUnit? attacker, TargetUnit? target, ObservableCollection<Modificator> mods)
        {
            if (attacker == null || target == null)
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
            // Есть минус 1 ту вунд
            if (mods.Any(m => m.Id == 8))
            {
                // Рерол 1
                if (mods.Any(m => m.Id == 3))
                {
                    // Анти х
                    if (mods.Any(m => m.Id == 9 && m.Condition != null))
                    {

                    }
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

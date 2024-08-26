using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
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
                        var modWithAnti = mods.Single(m => m.Id == 9);
                        // Если результат сравнения силы и стойкости больше анти х, то используем анти х для рола
                        // При этом минус 1 ту вунд не играет роли
                        if (resultedRoll >= modWithAnti.Condition)
                        {
                            return DiceRoller.RollTheDiceWithReroll1s((byte)modWithAnti.Condition);
                        }
                        // Если результат сравнения силы и стойкости меньше, то используем его
                        return DiceRoller.RollTheDiceWithReroll1s((byte)(resultedRoll + 1));
                    }
                    // Без анти х
                    return DiceRoller.RollTheDiceWithReroll1s((byte)(resultedRoll + 1));
                }
                // Полный рерол
                if (mods.Any(m => m.Id == 4))
                {
                    // Анти х
                    if (mods.Any(m => m.Id == 9 && m.Condition != null))
                    {
                        var modWithAnti = mods.Single(m => m.Id == 9);
                        // Если результат сравнения силы и стойкости больше анти х, то используем анти х для рола
                        // При этом минус 1 ту вунд не играет роли
                        if (resultedRoll >= modWithAnti.Condition)
                        {
                            return DiceRoller.RollTheDiceWithReroll((byte)modWithAnti.Condition);
                        }
                        // Если результат сравнения силы и стойкости меньше, то используем его
                        return DiceRoller.RollTheDiceWithReroll((byte)(resultedRoll + 1));
                    }
                    // Без анти х
                    return DiceRoller.RollTheDiceWithReroll((byte)(resultedRoll + 1));
                }
                // Без реролов
                return DiceRoller.RollTheDice((byte)(resultedRoll + 1));
            }
            // Без минус 1 ту вунд
            // Рерол 1
            if (mods.Any(m => m.Id == 3))
            {
                // Анти х
                if (mods.Any(m => m.Id == 9 && m.Condition != null))
                {
                    var modWithAnti = mods.Single(m => m.Id == 9);
                    // Если результат сравнения силы и стойкости больше анти х, то используем анти х для рола
                    if (resultedRoll >= modWithAnti.Condition)
                    {
                        return DiceRoller.RollTheDiceWithReroll1s((byte)modWithAnti.Condition);
                    }
                    // Если результат сравнения силы и стойкости меньше, то используем его
                    return DiceRoller.RollTheDiceWithReroll1s(resultedRoll);
                }
                // Без анти х
                return DiceRoller.RollTheDiceWithReroll1s(resultedRoll);
            }
            // Полный рерол
            if (mods.Any(m => m.Id == 4))
            {
                // Анти х
                if (mods.Any(m => m.Id == 9 && m.Condition != null))
                {
                    var modWithAnti = mods.Single(m => m.Id == 9);
                    // Если результат сравнения силы и стойкости больше анти х, то используем анти х для рола
                    if (resultedRoll >= modWithAnti.Condition)
                    {
                        return DiceRoller.RollTheDiceWithReroll((byte)modWithAnti.Condition);
                    }
                    // Если результат сравнения силы и стойкости меньше, то используем его
                    return DiceRoller.RollTheDiceWithReroll(resultedRoll);
                }
                // Без анти х
                return DiceRoller.RollTheDiceWithReroll(resultedRoll);
            }
            // Без реролов
            return DiceRoller.RollTheDice(resultedRoll);
        }
    }
}
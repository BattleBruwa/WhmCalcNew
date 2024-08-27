using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public static class AccuracyCalc
    {
        /// <summary>
        /// Расчитывает вероятность попасть атакой по цели.
        /// </summary>
        public static float ToHitRoll(AttackingUnit attacker, ObservableCollection<Modificator> mods)
        {
            if (attacker == null || mods == null)
            {
                return 0f;
            }
            // 0 = автохиты
            if (attacker.Accuracy == 0)
            {
                return 1f;
            }
            // Есть криты
            if (mods.Any(m => m.Id == 14 && m.Condition != null))
            {
                var modWithCrit = mods.Single(m => m.Id == 14);
                // С реролом 1
                if (mods.Any(m => m.Id == 1))
                {
                    if (attacker.Accuracy >= modWithCrit.Condition)
                    {
                        return DiceRoller.RollTheDiceWithReroll1s((byte)modWithCrit.Condition);
                    }
                    return DiceRoller.RollTheDiceWithReroll1s(attacker.Accuracy);
                }
                // С полным реролом
                if (mods.Any(m => m.Id == 2))
                {
                    if (attacker.Accuracy >= modWithCrit.Condition)
                    {
                        return DiceRoller.RollTheDiceWithReroll((byte)modWithCrit.Condition);
                    }
                    return DiceRoller.RollTheDiceWithReroll(attacker.Accuracy);
                }
                // Без рерола
                if (attacker.Accuracy >= modWithCrit.Condition)
                {
                    return DiceRoller.RollTheDice((byte)modWithCrit.Condition);
                }
                return DiceRoller.RollTheDice(attacker.Accuracy);
            }
            // Нет критов
            // С реролом 1
            if (mods.Any(m => m.Id == 1))
            {
                return DiceRoller.RollTheDiceWithReroll1s(attacker.Accuracy);
            }
            // С полным реролом
            if (mods.Any(m => m.Id == 2))
            {
                return DiceRoller.RollTheDiceWithReroll(attacker.Accuracy);
            }
            // Без критов и реролов
            return DiceRoller.RollTheDice(attacker.Accuracy);
        }
    }
}

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
            // На 4+
            if (mods.Any(m => m.Id == 14 && m.Condition == 4))
            {
                // С реролом 1
                if (mods.Any(m => m.Id == 1))
                {
                    HelperRR1(attacker.Accuracy, 4);
                }
                // С полным реролом
                if (mods.Any(m => m.Id == 2))
                {
                    HelperRRAll(attacker.Accuracy, 4);
                }
            }
            // На 5+
            if (mods.Any(m => m.Id == 14 && m.Condition == 5))
            {
                // С реролом 1
                if (mods.Any(m => m.Id == 1))
                {
                    HelperRR1(attacker.Accuracy, 5);
                }
                // С полным реролом
                if (mods.Any(m => m.Id == 2))
                {
                    HelperRRAll(attacker.Accuracy, 5);
                }
            }
            // Обычный крит на 6+
            // C реролом 1
            if (mods.Any(m => m.Id == 1))
            {
                return DiceRoller.RollTheDiceWithReroll1s(attacker.Accuracy);
            }
            // C полным реролом
            if (mods.Any(m => m.Id == 2))
            {
                return DiceRoller.RollTheDiceWithReroll(attacker.Accuracy);
            }
            // Без критов и реролов
            return DiceRoller.RollTheDice(attacker.Accuracy);
        }

        // Для повторяющегося кода
        // С реролом 1
        private static float HelperRR1(byte accuracy, byte modcon)
        {
            if (accuracy >= modcon)
            {
                return DiceRoller.RollTheDiceWithReroll1s(modcon);
            }
            return DiceRoller.RollTheDiceWithReroll1s(accuracy);
        }
        // С полным реролом
        private static float HelperRRAll(byte accuracy, byte modcon)
        {
            if (accuracy >= modcon)
            {
                return DiceRoller.RollTheDiceWithReroll(modcon);
            }
            return DiceRoller.RollTheDiceWithReroll(accuracy);
        }
    }
}

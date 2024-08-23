using System.Collections.ObjectModel;
using WhmCalcNew.Models;
using WhmCalcNew.Services.Calculations;

namespace WhmCalcNew.Engine.Calculations
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
            // Рерол 1
            if (mods.Any(m => m.Id == 1))
            {

            }
            // Рерол промахов
            if (mods.Any(m => m.Id == 2))
            {
                
            }
            // Криты без реролов
            if (mods.Any(m => m.Id == ))
            {
                return DiceRoller.RollTheDice(5);
            }

            return DiceRoller.RollTheDice((byte)attacker.Accuracy);
        }
    }
}

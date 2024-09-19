using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public static class AccuracyCalc
    {
        /// <summary>
        /// Расчитывает вероятность попасть атакой по цели.
        /// </summary>
        public static double ToHitRoll(byte accuracy, ObservableCollection<Modificator> mods)
        {
            // С реролом 1
            if (mods.Any(m => m.Id == 1))
            {
                return DiceRoller.RollTheDiceWithReroll1s(accuracy);
            }
            // С полным реролом
            if (mods.Any(m => m.Id == 2))
            {
                return DiceRoller.RollTheDiceWithReroll(accuracy);
            }
            // Без реролов
            return DiceRoller.RollTheDice(accuracy);
        }
    }
}

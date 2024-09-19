using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public static class ToWoundCalc
    {
        /// <summary>
        /// Расчитывает вунд ролл.
        /// </summary>
        public static double ToWoundRoll(byte rollNum, ObservableCollection<Modificator> mods)
        {

            // Есть -1 ту вунд
            if (mods.Any(m => m.Id == 8))
            {
                // С реролом 1
                if (mods.Any(m => m.Id == 3))
                {
                    return DiceRoller.RollTheDiceWithReroll1s((byte)(rollNum + 1));
                }
                // С полным реролом
                if (mods.Any(m => m.Id == 4))
                {
                    return DiceRoller.RollTheDiceWithReroll((byte)(rollNum + 1));
                }
                // Без реролов
                return DiceRoller.RollTheDice((byte)(rollNum + 1));
            }
            // Нет -1 ту вунд
            // С реролом 1
            if (mods.Any(m => m.Id == 3))
            {
                return DiceRoller.RollTheDiceWithReroll1s(rollNum);
            }
            // С полным реролом
            if (mods.Any(m => m.Id == 4))
            {
                return DiceRoller.RollTheDiceWithReroll(rollNum);
            }
            // Без реролов
            return DiceRoller.RollTheDice(rollNum);
        }
    }
}
using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public static class ArmorSaveCalc
    {
        public static float ToSaveRoll(AttackingUnit attacker, TargetUnit target, ObservableCollection<Modificator> mods)
        {
            byte resultedRoll = 0;
            // Если есть инвуль
            if (mods.Any(m => m.Id == 11))
            {
                var modWithInvul = mods.Single(m => m.Id == 11);
                byte invulCon = (byte)modWithInvul.Condition;
                // Если арморпен + армор больше инвуля, используем инвуль
                if (attacker.ArmorPen + target.Save >= invulCon)
                {
                    resultedRoll = invulCon;
                    return DiceRoller.RollTheDice(resultedRoll);
                }
                // Используем арморпен + армор, если это меньше инвуля
                resultedRoll = (byte)(attacker.ArmorPen + target.Save);
                return DiceRoller.RollTheDice(resultedRoll);
            }
            // Если нет инвуля
            resultedRoll = (byte)(attacker.ArmorPen + target.Save);
            return DiceRoller.RollTheDice(resultedRoll);
        }
    }
}

using System.Collections.ObjectModel;
using WhmCalcNew.Models;

namespace WhmCalcNew.Services.Calculations
{
    public static class ArmorSaveCalc
    {
        public static float ToSaveRoll(AttackingUnit? attacker, TargetUnit? target, ObservableCollection<Modificator> mods)
        {
            if (attacker == null || target == null)
            {
                return 0f;
            }

            byte resultedRoll = 0;
            // Если есть инвуль
            if (mods.Any(m => m.Id == 11 && m.Condition != null))
            {
                var modWithInvul = mods.Single(m => m.Id == 11);
                // Если арморпен + армор больше инвуля, используем инвуль
                if (attacker.ArmorPen + target.Save >= modWithInvul.Condition)
                {
                    resultedRoll = (byte)modWithInvul.Condition;
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

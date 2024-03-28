using WhmCalcNew.Models;

namespace WhmCalcNew.Engine
{
    public static class ArmorSaveCalc
    {
        public static float ToSaveRoll(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null || attacker.ArmorPen == null || target.Save == null)
            {
                return 0f;
            }

            int resultedRoll = 0;

            if (target.Invuln == null || target.Invuln == 0)
            {
                resultedRoll = (int)(attacker.ArmorPen + target.Save);
            }
            else
            {
                if (attacker.ArmorPen + target.Save >= target.Invuln)
                {
                    resultedRoll = (int)target.Invuln;
                }
                if (attacker.ArmorPen + target.Save < target.Invuln)
                {
                    resultedRoll = (int)(attacker.ArmorPen + target.Save);
                }
            }

            return DiceRoller.RollTheDice(resultedRoll);
        }
    }
}

using WhmCalcNew.Models;

namespace WhmCalcNew.Engine
{
    public static class AccuracyCalc
    {
        public static float ToHitRoll(AttackingUnit? attacker, TargetUnit? target)
        {
            if (attacker == null || target == null || attacker.Accuracy == null)
            {
                return 0f;
            }
            if (attacker.Accuracy == 0)
            {
                return AttacksOrDamageCalc.CalculateAorD(attacker.Attacks);
            }
            if (target.IsHardToHit == true)
            {
                attacker.Accuracy = (byte)(attacker.Accuracy - 1);
            }

            return DiceRoller.RollTheDice((byte)attacker.Accuracy);
        }
    }
}

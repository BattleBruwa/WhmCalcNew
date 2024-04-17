using WhmCalcNew.Models;

namespace WhmCalcNew.Engine.Calculations
{
    public static class AccuracyCalc
    {
        /// <summary>
        /// Расчитывает вероятность попасть атакой по цели.
        /// </summary>
        public static float ToHitRoll(AttackingUnit? attacker)
        {
            if (attacker == null || attacker.Accuracy == null)
            {
                return 0f;
            }
            // 0 = автохиты
            if (attacker.Accuracy == 0)
            {
                return 1;
            }
            // Криты на 5
            if (attacker.HasCritsOn5s == true && attacker.Accuracy > 5f)
            {
                return DiceRoller.RollTheDice(5);
            }

            return DiceRoller.RollTheDice((byte)attacker.Accuracy);
        }
    }
}

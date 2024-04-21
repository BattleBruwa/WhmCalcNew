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
                return 1f;
            }
            // Рерол 1
            if (attacker.HasRerollToHit1 == true)
            {
                // Криты на 5
                if (attacker.HasCritsOn5s == true && attacker.Accuracy > 5f)
                {
                    return DiceRoller.RollTheDiceWithReroll1s(5);
                }
                else
                {
                    return DiceRoller.RollTheDiceWithReroll1s((byte)attacker.Accuracy);
                }
            }
            // Рерол промахов
            if (attacker.HasRerollToHitAll == true)
            {
                // Криты на 5
                if (attacker.HasCritsOn5s == true && attacker.Accuracy > 5f)
                {
                    return DiceRoller.RollTheDiceWithReroll(5);
                }
                else
                {
                    return DiceRoller.RollTheDiceWithReroll((byte)attacker.Accuracy);
                }
            }
            return DiceRoller.RollTheDice((byte)attacker.Accuracy);
        }
    }
}

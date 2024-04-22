namespace WhmCalcNew.Engine.Calculations
{
    public static class DiceRoller
    {
        // Примерно равно 0.17
        private const float DiceRollSixPlus = (1f / 6f);

        // Примерно равно 0.33
        private const float DiceRollFivePlus = (2f / 6f);

        // Равно 0.5
        private const float DiceRollFourPlus = (3f / 6f);

        // Примерно равно 0.67
        private const float DiceRollThreePlus = (4f / 6f);

        // Примерно равно 0.83
        private const float DiceRollTwoPlus = (5f / 6f);

        /// <summary> Вероятность выбросить нужное значение на кубе.</summary>
        public static float RollTheDice(int input)
        {
            switch (input)
            {
                case <= 2: return DiceRollTwoPlus;
                case 3: return DiceRollThreePlus;
                case 4: return DiceRollFourPlus;
                case 5: return DiceRollFivePlus;
                case >= 6: return DiceRollSixPlus;
            }
        }

        /// <summary>
        /// Вероятность выбросить нужное значение на кубе с перебросом результата 1.
        /// </summary>
        public static float RollTheDiceWithReroll1s(int input)
        {
            switch (input)
            {
                case <= 2: return DiceRollTwoPlus + (DiceRollSixPlus * DiceRollTwoPlus);
                case 3: return DiceRollThreePlus + (DiceRollSixPlus * DiceRollThreePlus);
                case 4: return DiceRollFourPlus + (DiceRollSixPlus * DiceRollFourPlus);
                case 5: return DiceRollFivePlus + (DiceRollSixPlus * DiceRollFivePlus);
                case >= 6: return DiceRollSixPlus + (DiceRollSixPlus * DiceRollSixPlus);
            }
        }

        /// <summary>
        /// Вероятность выбросить нужное значение на кубе с перебросом провалов.
        /// </summary>
        public static float RollTheDiceWithReroll(int input)
        {
            switch (input)
            {
                case <= 2: return DiceRollTwoPlus + (DiceRollSixPlus * DiceRollTwoPlus);
                case 3: return DiceRollThreePlus + (DiceRollFivePlus * DiceRollThreePlus);
                case 4: return DiceRollFourPlus + (DiceRollFourPlus * DiceRollFourPlus);
                case 5: return DiceRollFivePlus + (DiceRollThreePlus * DiceRollFivePlus);
                case >= 6: return DiceRollSixPlus + (DiceRollTwoPlus * DiceRollSixPlus);
            }
        }
    }
}

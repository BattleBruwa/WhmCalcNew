namespace WhmCalcNew.Engine.Calculations
{
    public static class DiceRoller
    {
        /// <summary> Вероятность выбросить нужное значение на кубе.</summary>
        /// <returns>0.83 для 2+ 0.67 для 3+ 0.5 для 4+ 0.33 для 5+ 0.17 для 6+</returns>
        public static float RollTheDice(int input)
        {
            switch (input)
            {
                case <= 2: return 0.83f;
                case 3: return 0.67f;
                case 4: return 0.5f;
                case 5: return 0.33f;
                case >= 6: return 0.17f;
            }
        }

        /// <summary>
        /// Вероятность выбросить нужное значение на кубе с перебросом результата 1.
        /// </summary>
        public static float RollTheDiceWithReroll1s(int input)
        {
            switch (input)
            {
                case <= 2: return (float)Math.Round(0.83f + (0.17f * 0.83f), 2);
                case 3: return (float)Math.Round(0.67f + (0.17f * 0.67f), 2);
                case 4: return (float)Math.Round(0.5f + (0.17f * 0.5f), 2);
                case 5: return (float)Math.Round(0.33f + (0.17f * 0.33f), 2);
                case >= 6: return (float)Math.Round(0.17f + (0.17f * 0.17f), 2);
            }
        }

        /// <summary>
        /// Вероятность выбросить нужное значение на кубе с перебросом провалов.
        /// </summary>
        public static float RollTheDiceWithReroll(int input)
        {
            switch (input)
            {
                case <= 2: return (float)Math.Round(0.83f + (0.17f * 0.83f), 2);
                case 3: return (float)Math.Round(0.67f + (0.33f * 0.67f), 2);
                case 4: return (float)Math.Round(0.5f + (0.5f * 0.5f), 2);
                case 5: return (float)Math.Round(0.33f + (0.67f * 0.33f), 2);
                case >= 6: return (float)Math.Round(0.17f + (0.83f * 0.17f), 2);
            }
        }
    }
}

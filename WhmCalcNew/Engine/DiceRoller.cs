namespace WhmCalcNew.Engine
{
    public static class DiceRoller
    {
        /// <summary>Дает вероятность выбросить нужное значение на кубе.</summary>
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
    }
}

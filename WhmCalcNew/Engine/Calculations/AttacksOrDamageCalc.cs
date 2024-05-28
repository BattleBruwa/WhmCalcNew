namespace WhmCalcNew.Engine.Calculations
{
    public static class AttacksOrDamageCalc
    {
        /// <summary>
        /// Расчитывает количество атак или урон каждой атаки.
        /// </summary>
        public static float CalculateAorD(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0f;
            }

            bool result = float.TryParse(input, out var number);

            // Если result запарсился успешно, возвращаем number,
            if (result == true)
            {
                return number;
            }
            // если нет, ищем D
            else
            {
                float amount = 0;
                int indexOfD = input.IndexOf('D', StringComparison.CurrentCultureIgnoreCase);

                float numBeforeD = 0;
                if (indexOfD == 0 || input[indexOfD - 1].Equals(' ') || input[indexOfD - 1].Equals('1'))
                {
                    numBeforeD = 1;
                }
                else
                {
                    numBeforeD = (float)char.GetNumericValue(input[indexOfD - 1]);
                    if (numBeforeD == 0)
                    {
                        string _concatStringD = string.Concat(input[indexOfD - 2], input[indexOfD - 1]);
                        numBeforeD = (float)Convert.ToDouble(_concatStringD);
                    }
                }

                float numAfterD = 0;
                if (char.GetNumericValue(input[indexOfD + 1]) == 3)
                {
                    numAfterD = 2.0f;
                }
                if (char.GetNumericValue(input[indexOfD + 1]) == 6)
                {
                    numAfterD = 3.5f;
                }

                // Проверка на наличие в строке выражения
                int indexOfPlus = input.IndexOf('+');

                if (indexOfPlus != -1)
                {
                    // Число после плюса
                    float numAfterPlus = (float)char.GetNumericValue(input[indexOfPlus + 1]);
                    if (numAfterPlus == 1)
                    {
                        if((indexOfPlus + 2) == input.Length)
                        {
                            numAfterPlus = 1;
                        }
                        else
                        {
                            string _concatStringP = string.Concat(input[indexOfPlus + 1], input[indexOfPlus + 2]);
                            numAfterPlus = (float)Convert.ToDouble(_concatStringP);
                        }
                    }

                    amount = (numBeforeD * numAfterD) + numAfterPlus;
                }
                else
                {
                    amount = numBeforeD * numAfterD;
                }

                return amount;
            }
        }
    }
}

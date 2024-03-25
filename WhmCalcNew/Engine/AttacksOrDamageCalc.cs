namespace WhmCalcNew.Engine
{
    public static class AttacksOrDamageCalc
    {
        public static float CalculateAorD (string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            bool result = float.TryParse(input, out var number);
            if (result == true)
            {
                return number;
            }
            else
            {
                float amount = 0;
                int indexOfD = input.IndexOf('D');

                float numBeforeD = 0;
                if (input[indexOfD - 1].Equals(' ') || input[indexOfD - 1].Equals('1'))
                {
                    numBeforeD = 1;
                }
                else
                {
                    numBeforeD = (float)(Char.GetNumericValue(input[indexOfD - 1]));
                    if (numBeforeD == 0)
                    {
                        string _newString = string.Concat(input[indexOfD - 2], input[indexOfD - 1]);
                        numBeforeD = (float)(Convert.ToDouble(_newString));
                    }
                }

                float numAfterD = 0;
                if (Char.GetNumericValue(input[indexOfD + 1]) == 3)
                {
                    numAfterD = 2.0f;
                }
                if (Char.GetNumericValue(input[indexOfD + 1]) == 6)
                {
                    numAfterD = 3.5f;
                }

                amount = numBeforeD + numAfterD;
                return amount;
            }
        }
    }
}

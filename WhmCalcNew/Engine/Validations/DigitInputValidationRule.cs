using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class DigitInputValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(@"\d{2}");
            string? input = value.ToString();

            if (regex.IsMatch(input) == false)
            {
                if (input.Length > 2 || input.Length < 0)
                {
                    return new ValidationResult(false, "Поле должно содержать до 2 чисел");
                }
                return new ValidationResult(false, "Поле должно содержать число");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

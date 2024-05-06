using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class StrenghtValidationRule : ValidationRule
    {
        private const string _strPattern = @"^([0-9]|[1-2][0-9])$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_strPattern);
            string? input = value.ToString();

            if (regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Сила должна иметь значение от 1 до 29.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

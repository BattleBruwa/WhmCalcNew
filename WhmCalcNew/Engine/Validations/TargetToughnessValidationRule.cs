using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    internal class TargetToughnessValidationRule : ValidationRule
    {
        private const string _toughPattern = @"^([0-9]|[1-2][0-9])$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_toughPattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Стойкость должна иметь значение от 1 до 29.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

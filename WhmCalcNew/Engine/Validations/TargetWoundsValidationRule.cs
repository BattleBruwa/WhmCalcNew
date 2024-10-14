using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    internal class TargetWoundsValidationRule : ValidationRule
    {
        private const string _woundsPattern = @"^([1-9]|[1-9][0-9])$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_woundsPattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Количество вунд должно иметь значение от 1 до 99.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

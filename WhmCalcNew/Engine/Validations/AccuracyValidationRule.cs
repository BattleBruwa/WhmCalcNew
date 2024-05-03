using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class AccuracyValidationRule : ValidationRule
    {
        private const string _wsPattern = @"^[0-6]{1}$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_wsPattern);
            string? input = value.ToString();

            if (regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Некорректное число");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
        
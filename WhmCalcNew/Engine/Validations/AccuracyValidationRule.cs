using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class AccuracyValidationRule : ValidationRule
    {
        private const string _wsPattern = @"^[0-6]$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_wsPattern);
            
            string? input = value.ToString();
            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, ValidationMessages.AccuracyError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
        
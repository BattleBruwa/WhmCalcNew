using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    internal class TargetSaveValidationRule : ValidationRule
    {
        private const string _savePattern = @"^[2-7]$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_savePattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, ValidationMessages.TargetSaveError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    internal class TargetNameValidationRule : ValidationRule
    {
        private const string _namePattern = @"^\S{1}.{0,14}$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_namePattern);
            string? input = value.ToString();
            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, ValidationMessages.TargetNameError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

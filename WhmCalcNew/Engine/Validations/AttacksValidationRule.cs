using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class AttacksValidationRule : ValidationRule
    {
        private const string _attacksPattern = @"^([0-9]|[1-9][0-9]|(D|d)[36]|([1-9]|1[0-9])(D|d)[36]|(D|d)[36][+]([1-9]|1[0-9])|([1-9]|1[0-9])(D|d)[36][+]([1-9]|1[0-9]))$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_attacksPattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, ValidationMessages.AttacksError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

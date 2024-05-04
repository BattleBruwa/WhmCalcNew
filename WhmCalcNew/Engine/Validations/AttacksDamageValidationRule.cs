using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class AttacksDamageValidationRule : ValidationRule
    {
        private const string _attacksOrDamagePattern = @"^([0-9]|[1-2]{1}[0-9]{1})$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_attacksOrDamagePattern);
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

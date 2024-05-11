using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class AttacksDamageValidationRule : ValidationRule
    {
        private const string _attacksOrDamagePattern = @"^([1-9]|[1-9][0-9]|(D|d)[36]|[1-9](D|d)[36]|[1-9][0-9](D|d)[36])$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_attacksOrDamagePattern);
            string? input = value.ToString();

            if (regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Количество атак должно иметь значение от 1 до 99 или значение в формате xDx.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

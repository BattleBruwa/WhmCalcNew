using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class DamageValidationRule: ValidationRule
    {
        private const string _damagePattern = @"^([1-9]|[1-9][0-9]|(D|d)[36]|([1-9]|1[0-9])(D|d)[36]|(D|d)[36][+]([1-9]|1[0-9])|([1-9]|1[0-9])(D|d)[36][+]([1-9]|1[0-9]))$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_damagePattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Урон должен иметь значение от 1 до 99 или значение в формате xDx.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

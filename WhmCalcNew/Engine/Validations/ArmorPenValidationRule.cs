using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class ArmorPenValidationRule : ValidationRule
    {
        private const string _armorPenPattern = @"^[0-5]$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_armorPenPattern);
            string? input = value.ToString();

            if (regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Пробивание брони должно иметь значение от 0 до 5.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class ArmorPenValidationRule : ValidationRule
    {
        private const string _armorPenPattern = @"^([0-9]|[1-2]{1}[0-9]{1})$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_armorPenPattern);
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

using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    public class ArmorPenValidationRule : ValidationRule
    {
        private const string _armorPenPattern = @"^[0-6]$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_armorPenPattern);
            string? input = value.ToString();

            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, ValidationMessages.ArmorPenError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

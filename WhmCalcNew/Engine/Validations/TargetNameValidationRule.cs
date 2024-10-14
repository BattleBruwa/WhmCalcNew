﻿using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WhmCalcNew.Engine.Validations
{
    internal class TargetNameValidationRule : ValidationRule
    {
        private const string _namePattern = @"^([0-9]|[1-2][0-9])$";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(_namePattern);
            string? input = value.ToString();
            if (input == null || regex.IsMatch(input) == false)
            {
                return new ValidationResult(false, "Некорректное имя");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}

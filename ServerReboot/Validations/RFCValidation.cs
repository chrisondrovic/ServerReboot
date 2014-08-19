﻿using System;
using System.Windows.Controls;

namespace ServerReboot.Validations
{
    public class RFCValidation : ValidationRule
    {
        private string _number;

        public string RFC { get { return _number; } set { _number = value; } }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string number = string.Empty;
            try
            {
                if (((string)value).Length > 0)
                {
                    number = ((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
            if (number.Length < 11)
            {
                return new ValidationResult(false, "RFC number must be 11 characters");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
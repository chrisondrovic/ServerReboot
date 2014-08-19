using System;
using System.Windows.Controls;

namespace ServerReboot.Validations
{
    public class ManagerValidation : ValidationRule
    {
        private string _manager;

        public string Manger { get { return _manager; } set { _manager = value; } }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string manager = string.Empty;
            try
            {
                if (((string)value).Length > 0)
                {
                    manager = ((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
            if (manager.Length < 5)
            {
                return new ValidationResult(false, "Manager name must be more than 5 characters");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

using System;
using System.Windows.Controls;

namespace ServerReboot.Validations
{
    public class ManagerValidation : ValidationRule
    {
        private string _manager;

        public string Manger { get { return _manager; } set { _manager = value; } }

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult" /> object.
        /// </returns>
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

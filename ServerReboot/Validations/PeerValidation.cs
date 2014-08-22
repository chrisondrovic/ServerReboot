using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ServerReboot.Validations
{
    class PeerValidation : ValidationRule
    {
        private string _peer;
        /// <summary>
        /// Gets or sets the peer.
        /// </summary>
        /// <value>
        /// The peer.
        /// </value>
        public string Peer { get { return _peer; } set { _peer = value; } }

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
            string peer = string.Empty;
            try
            {
                if (((string)value).Length > 0)
                {
                    peer = ((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
            if (peer.Length < 5)
            {
                return new ValidationResult(false, "Peer name must be more than 5 characters");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

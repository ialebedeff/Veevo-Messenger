using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Veevo.DSK.Validations
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public string? Email { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Поле не заполнено.")
                : ValidationResult.ValidResult;
        }
    }
}

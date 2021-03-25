using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace WpfAppNetTest.Validations
{
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (double.TryParse(value.ToString(),out double dValue))
            {
                if (0 <= dValue && dValue <= 100)
                    return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Validation failed.");
        }
    }
}

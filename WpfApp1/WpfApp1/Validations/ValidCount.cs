using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validations
{
    public class ValidCount : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string count = value as string;
            if (!string.IsNullOrEmpty(count) && count.All((char c) => char.IsDigit(c)) && int.Parse(count) > 0)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, null);
        }
    }
}

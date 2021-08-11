using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validations
{
    class ValidName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (name == null || name.Length < 1)
                return new ValidationResult(false, null);

            string hebrewLetters = "אבגדהוזחטיכלמנסעפצקרשתםךץףן ";
            string englishLetters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (name.All((char c) => englishLetters.Contains(c)) || name.All((char c) => hebrewLetters.Contains(c)))
                return ValidationResult.ValidResult;

            return new ValidationResult(false, null);
        }
    }
}

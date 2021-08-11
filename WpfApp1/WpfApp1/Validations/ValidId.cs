using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validations
{

    class ValidId : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string id = value as string;

            try
            {
                int.Parse(id);
            }
            catch
            {
                return new ValidationResult(false, null);
            }

            if (id.Length > 9)
                return new ValidationResult(false, null);



            id = id.PadLeft(9, '0');
            int incNum, sum = 0;

            for (int i = 0; i < 9; i++)
            {
                incNum = int.Parse(id[i].ToString()) * ((i % 2) + 1);
                sum += (incNum > 9) ? incNum - 9 : incNum;
            }

            if (sum % 10 == 0)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, null);
        }
    }
}

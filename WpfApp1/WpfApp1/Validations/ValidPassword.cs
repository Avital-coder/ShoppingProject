using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Validations
{
    public class ValidPassword
    {
        public bool IsValidPassword(string password)
        {

            if (password == null)
                return false;

            //string strongLetters = "~!@#$%^&*";

            //if (password.Length > 6 && password.Any((char c) => strongLetters.Contains(c)))
            if (password.Length >= 6)
                return true;

            return false;
        }
    }
}

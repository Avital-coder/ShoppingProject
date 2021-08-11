using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Other
{
    class GetMonthLabel
    {
        public string[] GetLabels(int NumberOfMounths)
        {
            string[] Labels = new string[NumberOfMounths];
            for (int i = 0; i < NumberOfMounths; i++)
            {
                Labels[i] = DateTime.Now.AddMonths(-i).ToString("MMM yy");
            }
            return Labels.Reverse().ToArray();
        }
    }
}

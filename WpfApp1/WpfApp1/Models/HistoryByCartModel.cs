using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class HistoryBySCartModel
    {
        IBL BL;
        public HistoryBySCartModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.CurrentUser);
        }
        public IEnumerable<double> GetHistoryBySCart(string[] labels)
        {
            return BL.GetHistoryByCart(labels);
        }
    }
}

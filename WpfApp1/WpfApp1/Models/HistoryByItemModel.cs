using BL;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class HistoryByItemModel
    {
        IBL BL;
        public HistoryByItemModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.CurrentUser);
        }
        #region getters
        public IEnumerable<double> GetHistoryByItem(string ItemName, string[] Mounths)
        {

            return BL.GetHistoryByItem(ItemName, Mounths);
        }

        public IEnumerable<string> GetItems()
        {
            return BL.GetAllItems().Select(item => item.Name).Distinct();
        }
        #endregion

    }
}

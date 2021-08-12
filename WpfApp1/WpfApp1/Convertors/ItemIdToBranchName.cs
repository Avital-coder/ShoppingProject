using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1.Convertors
{
    class ItemIdToBranchName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string id = value as string;
            if (id == null)
                return null;
            var item = new BL.BLImp(((App)Application.Current).Currents.LoggedUser).GetAllItems().Where(x => x.Id == id).FirstOrDefault();
            return item == null ? null : item.BranchName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
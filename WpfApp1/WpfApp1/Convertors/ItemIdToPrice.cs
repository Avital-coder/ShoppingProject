using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    class ItemIdToPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string id = value as string;
            if (id == null)
                return 0;
            var item = new BL.BLImp(((App)Application.Current).Currents.LoggedUser).GetAllItems().Where(x => x.Id == id).FirstOrDefault();
            return item == null ? 0 : item.Price;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

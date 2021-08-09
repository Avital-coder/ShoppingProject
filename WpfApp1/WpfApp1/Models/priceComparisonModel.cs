using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using System.Windows;

namespace WpfApp1.Models
{
    class priceComparisonModel
    {
        IBL BL;
        public priceComparisonModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.currentUser);
        }
        
        public IEnumerable<string> GetPriceComparison(string ItemName)
        {
            return BL.GetPriceComparison(ItemName);
        }

        public IEnumerable<string> GetItems()
        {
            return BL.GetAllItems().Select(item => item.Name).Distinct().OrderBy(item => item);
        }
        public IEnumerable<string> GetBranches()
        {
            return BL.GetAllBranches();
        }

        public IEnumerable<Item> GetItemsByName(string ItemName)
        {
            return BL.GetAllItems(item => item.Name == ItemName);
        }

        public Dictionary<string, double> GetPriceOptions(string[] Shops, IEnumerable<string> itemsList)
        {
            Dictionary<string, double> priceOptions = new Dictionary<string, double>();
            //List<double> CartsSize = new List<double>();
            foreach (var Shop in Shops)
            {
                priceOptions.Add(Shop,BL.GetCartPriceByShopName(Shop, itemsList));
            }
            return priceOptions;
        }
    }
}

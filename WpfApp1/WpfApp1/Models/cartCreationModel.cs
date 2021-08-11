using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Others;
using BE;
using BL;

namespace WpfApp1.Models
{
    class CartCreationModel
    {
        IBL BL;
        public CartCreationModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.CurrentUser);
        }

        public IEnumerable<string> GetItems()
        {
            return BL.GetAllItems().Select(item => item.Name).Distinct().OrderBy(item => item);
        }
        public IEnumerable<Item> GetItemsByName(string ItemName)
        {
            return BL.GetAllItems(item => item.Name == ItemName);
        }

        public string GetCheapestBranchPerItem(string itemName)
        {
            List<string> branchesList = BL.GetPriceComparison(itemName).ToList();
            string cheapestBranch = branchesList[0];
            float cheapestPrice = float.Parse(cheapestBranch.Split('\n')[1].Substring(1));
            foreach (var shop in branchesList)
            {
                float price = float.Parse(shop.Split('\n')[1].Substring(1));
                if (price < cheapestPrice)
                {
                    cheapestBranch = shop;
                    cheapestPrice = price;
                }

            };
            return cheapestBranch;
        }

        public Dictionary<string, List<string>> GetBuyingOffer(List<string> itemsName)
        {
            return BL.AnalizeHistory(itemsName);
        }

        public void CreatePDF(List<object[]> items)
        {
            BL.CreatePDF(items);
        }
    }
}

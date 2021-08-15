using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class LastPurchaseModel
    {
        IBL BL;
        public LastPurchaseModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.CurrentUser);
        }

        #region getters
        public List<Item> GetItemsList()
        {
            return BL.GetAllItems();
        }
        public ObservableCollection<string> GetBranchsList(string value)
        {
            return new ObservableCollection<string>
                (GetItemsList()
                .Where(item => item.Name == value)
                .Select(items => items.ShopName + " " + items.BranchName)
                 );
        }

        public Item GetItem(Func<Item, bool> p)
        {
            return GetItemsList().Where<Item>(p).FirstOrDefault();
        }

        public List<string> GetItemsNamesList()
        {
            return GetItemsList()
                .GroupBy(item => item.Name)
                .Select(items => items.First().Name).ToList();
        }
        public List<PurchaseItem> GetPurchaseItems()
        {
            return BL.GetLastPurchase();
        }


        #endregion

        #region other tools
        public bool AddPurchase(PurchaseItem purchaseItem)
        {
            return BL.AddPurchase(purchaseItem);
        }
        public void DeletePurchaseFromUserFile(PurchaseItem purchaseItem)
        {
            BL.DeletePurchaseFromUserFile(purchaseItem);
        }
        #endregion
    }
}

using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void SaveNewItemsGoogleDrive(); // this func download the new images from google drive and then delete them from the drive
        List<Item> GetAllItems(Func<Item, bool> predicate = null);
        List<PurchaseItem> GetAllPurchases(Func<PurchaseItem, bool> predicate = null);
        List<PurchaseItem> GetAllPurchasesOfAllUsers();
        List<User> GetAllUsers(Func<User, bool> predicate = null);
        bool AddPurchase(PurchaseItem purchaseItem);
        void AddItem(Item item);
        bool AddUser(User user);
        void DeletePurchaseFromUserFile(PurchaseItem PurchaseItem);
        List<PurchaseItem> GetLastPurchase();
        double GetCartPriceByShopName(string ShopName, IEnumerable<string> itemsName);
        IEnumerable<double> GetHistoryByShop(string shopName, string[] Mounths);
        IEnumerable<string> GetAllBranches();
        IEnumerable<string> GetAllShops();
        IEnumerable<double> GetHistoryByItem(string itemName, string[] mounths);
        IEnumerable<double> GetHistoryBySCart(string[] Mounths);
        IEnumerable<string> GetPriceComparison(string ItemName);
        Dictionary<string, List<string>> AnalizeHistory(List<string> items);
        void CreatePDF(List<object[]> items);

    }
}

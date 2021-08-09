using BE;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        List<PurchaseItem> GetLastPurchase();
        //for specific user
        List<Item> GetAllItems(Func<Item, bool> predicate = null);
        List<PurchaseItem> GetAllPurchases(Func<PurchaseItem, bool> predicate = null);

        List<PurchaseItem> GetAllPurchasesOfAllUsers();
        List<User> GetAllUsers(Func<User, bool> predicate = null);
        void AddPurchase(PurchaseItem purchaseItem);
        void AddItem(Item item);
        void AddUser(User user);
        void DeletePurchaseFromUserFile(PurchaseItem purchaseItem);
        void CreatePDF(List<object[]> items);
    }
}

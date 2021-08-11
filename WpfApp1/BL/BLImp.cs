using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public class BLImp:IBL
    {
        public IDAL dal { get; set; }
        public BLImp(User user)
        {
            dal = new DALImp(user);
        }
        public bool AddPurchase(PurchaseItem purchaseItem)
        {
            try
            {
                purchaseItem.Id = FindNextPurchaseId();
                dal.AddPurchase(purchaseItem);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool AddUser(User newUser)
        {
            try
            {

                if (newUser.FirstName == null || newUser.LastName == null || newUser.Id == null || newUser.Mail == null || newUser.Password == null)
                    return false;

                if (newUser.Password.Length < 6)
                    return false;

                var list = dal.GetAllUsers(user => user.Id == newUser.Id || user.Mail == newUser.Mail);

                if (list == null || list.Count == 0)
                {
                    dal.AddUser(newUser);
                    return true;
                }

                return false;

            }
            catch
            {
                return false;
            }

        }
        /*
        public void SaveNewItemsGoogleDrive()
        {
            throw new NotImplementedException();
        }*/
        private string FindNextPurchaseId()
        {
            var AllPurchases = GetAllPurchasesOfAllUsers();
            if (AllPurchases == null || AllPurchases.Count == 0)
                return "1";
            return (AllPurchases
                   .Select(item => int.Parse(item.Id)).Max() + 1).ToString();
        }
        public List<Item> GetAllItems(Func<Item, bool> predicate = null)
        {
            return dal.GetAllItems(predicate);
        }

        public List<PurchaseItem> GetAllPurchases(Func<PurchaseItem, bool> predicate = null)
        {
            return dal.GetAllPurchases(predicate);
        }
        public List<PurchaseItem> GetAllPurchasesOfAllUsers()
        {
            return dal.GetAllPurchasesOfAllUsers();
        }

        public List<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            return dal.GetAllUsers(predicate);
        }
        public IEnumerable<string> GetAllShops()
        {
            return GetAllItems().Select(item => item.ShopName).Distinct();
        }
        public IEnumerable<string> GetAllBranches()
        {
            return GetAllItems().Select(item => item.ShopName + " " + item.BranchName).Distinct();

        }
        public IEnumerable<string> GetPriceComparison(string ItemName)
        {
            List<string> PriceComparison = new List<string>();

            foreach (var item in dal.GetAllItems(item => item.Name == ItemName))
            {
                PriceComparison.Add(item.ShopName + " " + item.BranchName + "\n" + item.Price.ToString("C"));
            }

            return PriceComparison;
        }
        public double GetCartPriceByShopName(string ShopName, IEnumerable<string> itemsName)
        {
            double sum = 0;
            List<Item> Items = GetAllItems(item => item.ShopName + " " + item.BranchName == ShopName && itemsName.Contains(item.Name));
            foreach (var item in Items)
            {
                sum += item.Price;
            }
            return sum;
        }
        private string GetItemNameById(string Id)
        {
            return dal.GetAllItems(item => item.Id == Id).FirstOrDefault().Name;
        }
        public void CreatePDF(List<object[]> items)
        {
            dal.CreatePDF(items);
        }
        /*
        public void DeletePurchaseFromUserFile(PurchaseItem PurchaseItem)
        {
            dal.DeletePurchaseFromUserFile(PurchaseItem);
        }*/
    }
}

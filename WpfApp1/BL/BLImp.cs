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
        public void AddItem(Item item)
        {
            dal.AddItem(item);
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

        public IEnumerable<double> GetHistoryByShop(string shopName, string[] Mounths)
        {
            double[] values = new double[Mounths.Length];
            for (int i = 0; i < Mounths.Length; i++)
            {
                values[i] = GetHistoryByShopAndMounth(shopName, Mounths[i]);
            }
            return values;
        }
        public List<PurchaseItem> GetLastPurchase()
        {
            return dal.GetLastPurchase();
        }
        private double GetHistoryByShopAndMounth(string shopName, string Mounth)
        {
            double sum = 0;
            foreach (var Purchases in GetAllPurchases())
            {
                Item item = GetAllItems(x => x.Id == Purchases.ItemId).FirstOrDefault();

                if (item != null && item.ShopName == shopName && Purchases.Date.ToString("MMM yy") == Mounth)
                    sum += int.Parse(Purchases.Count) * item.Price;
            }
            return sum;
        }

        public IEnumerable<double> GetHistoryByItem(string itemName, string[] Mounths)
        {
            double[] values = new double[Mounths.Length];
            for (int i = 0; i < Mounths.Length; i++)
            {
                values[i] = GetHistoryByItemAndMounth(itemName, Mounths[i]);
            }
            return values;
        }
        private double GetHistoryByItemAndMounth(string itemName, string Mounth)
        {
            double count = 0;
            foreach (var Purchases in GetAllPurchases())
            {
                Item item = GetAllItems(x => x.Id == Purchases.ItemId).FirstOrDefault();

                if (item != null && item.Name == itemName && Purchases.Date.ToString("MMM yy") == Mounth)
                    count += double.Parse(Purchases.Count);
            }
            return count;
        }

        public IEnumerable<double> GetHistoryBySCart(string[] Mounths)
        {
            double[] values = new double[Mounths.Length];
            for (int i = 0; i < Mounths.Length; i++)
            {
                values[i] = GetHistoryBySCartMounth(Mounths[i]);
            }
            return values;
        }

        private double GetHistoryBySCartMounth(string Mounth)
        {
            double sum = 0;
            foreach (var Purchases in GetAllPurchases())
            {
                Item item = GetAllItems(x => x.Id == Purchases.ItemId).FirstOrDefault();
                if (item != null && Purchases.Date.ToString("MMM yy") == Mounth)
                    sum += double.Parse(Purchases.Count) * item.Price;
            }
            return sum;
        }

        public void SaveNewItemsGoogleDrive()
        {
            throw new NotImplementedException();
        }
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
        
        public void DeletePurchaseFromUserFile(PurchaseItem PurchaseItem)
        {
            dal.DeletePurchaseFromUserFile(PurchaseItem);
        }



        public Dictionary<string, List<string>> AnalizeHistory(List<string> itemsName)
        {
            if (itemsName == null || itemsName.Count == 0)
                return null;
            Dictionary<string, Dictionary<string, int>> analizeDict = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, List<string>> itemsInPurchase = new Dictionary<string, List<string>>();
            List<PurchaseItem> Purchases = GetAllPurchases();
            foreach (var purchase in Purchases)
            {
                string dateOfPurchase = purchase.Date.ToString("dd.MM.yyyy");
                if (!itemsInPurchase.Keys.Contains(dateOfPurchase))
                    itemsInPurchase.Add(dateOfPurchase, new List<string> { GetItemNameById(purchase.ItemId) });
                else if (!itemsInPurchase[dateOfPurchase].Contains(GetItemNameById(purchase.ItemId)))
                    itemsInPurchase[dateOfPurchase].Add(GetItemNameById(purchase.ItemId));
            }
            foreach (var item in itemsName)
            {
                Dictionary<string, int> connectionCounter = new Dictionary<string, int>();
                foreach (var itemsOfPurchase in itemsInPurchase)
                {
                    if (itemsOfPurchase.Value.Contains(item))
                    {
                        foreach (var tempItem in itemsOfPurchase.Value)
                        {
                            if (tempItem != item)
                            {
                                if (!connectionCounter.Keys.Contains(tempItem))
                                    connectionCounter.Add(tempItem, 1);
                                else
                                    connectionCounter[tempItem]++;
                            }
                        }

                    }
                }
                analizeDict.Add(item, connectionCounter);
            }
            Dictionary<string, int> allConnectionCounter = new Dictionary<string, int>();
            foreach (var itemAnalize in analizeDict.Values)
            {
                foreach (var itemCounter in itemAnalize)
                {
                    if (!itemsName.Contains(itemCounter.Key))
                    {
                        if (!allConnectionCounter.Keys.Contains(itemCounter.Key))
                            allConnectionCounter.Add(itemCounter.Key, itemCounter.Value);
                        else
                            allConnectionCounter[itemCounter.Key] += itemCounter.Value;
                    }
                }
            }
            if (allConnectionCounter.Count == 0)
                return null;
            var sortedAllConnectionCounter = allConnectionCounter.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> suggestedItems = new List<string>();
            if (sortedAllConnectionCounter.Count <= 3)
                for (int i = 0; i < 3; i++)
                {
                    var tempItem = sortedAllConnectionCounter.Keys.ElementAtOrDefault(i);
                    if (tempItem == null)
                        continue;
                    suggestedItems.Add(tempItem);
                }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    suggestedItems.Add(sortedAllConnectionCounter.Keys.ElementAt(sortedAllConnectionCounter.Count - i));
                }
            }
            Dictionary<string, List<string>> pairsOfSuggestions = new Dictionary<string, List<string>>();
            {
                foreach (var suggestedItem in suggestedItems)
                {
                    string maxConnector = "null";
                    string maxConnector2 = "null";
                    int maxValueConnector = 0;
                    int maxValueConnector2 = 0;

                    foreach (var analizedItem in analizeDict)
                    {
                        if (analizedItem.Value.Keys.Contains(suggestedItem))
                        {
                            if (analizedItem.Value[suggestedItem] > maxValueConnector)
                            {
                                maxConnector = analizedItem.Key;
                                maxValueConnector = analizedItem.Value[suggestedItem];
                            }
                            if (analizedItem.Value[suggestedItem] > maxValueConnector2 && maxConnector != analizedItem.Key)
                            {
                                maxConnector2 = analizedItem.Key;
                                maxValueConnector2 = analizedItem.Value[suggestedItem];
                            }
                        }
                    }
                    if (maxConnector != "null" && pairsOfSuggestions.Keys.Contains(maxConnector))
                        pairsOfSuggestions[maxConnector].Add(suggestedItem);
                    else if (maxConnector != "null")
                        pairsOfSuggestions.Add(maxConnector, new List<string>() { suggestedItem });
                    if (maxConnector2 != "null" && pairsOfSuggestions.Keys.Contains(maxConnector2))
                        pairsOfSuggestions[maxConnector2].Add(suggestedItem);
                    else if (maxConnector2 != "null")
                        pairsOfSuggestions.Add(maxConnector2, new List<string>() { suggestedItem });
                }
            }
            if (pairsOfSuggestions.Count <= 3)
                return pairsOfSuggestions;
            var sortedPairsOfSuggestions = pairsOfSuggestions.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            int j = 0;
            while (sortedPairsOfSuggestions.Count != 3)
            {
                bool canDelete = false;
                var mayDelete = sortedPairsOfSuggestions.ElementAt(j);
                foreach (var suggestedItem in mayDelete.Value)
                {
                    canDelete = false;
                    foreach (var pair in sortedPairsOfSuggestions)
                    {
                        if (pair.Value.Contains(suggestedItem))
                        {
                            canDelete = true;
                            break;
                        }
                    }
                    if (canDelete == false)
                        break;
                }
                if (canDelete)
                {
                    sortedPairsOfSuggestions.Remove(sortedPairsOfSuggestions.ElementAt(j).Key);
                }
                j++;
            }
            return sortedPairsOfSuggestions;
        }

    }
}

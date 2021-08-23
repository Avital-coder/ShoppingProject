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

        // get total purchases price for specific shop
        public IEnumerable<double> GetHistoryByShop(string shopName, string[] Months)
        {
            double[] values = new double[Months.Length];
            for (int i = 0; i < Months.Length; i++)
            {
                values[i] = GetHistoryByShopAndMonth(shopName, Months[i]);
            }
            return values;
        }
        public List<PurchaseItem> GetLastPurchase()
        {
            return dal.GetLastPurchase();
        }

        // get one month's total purchases price for specific shop
        private double GetHistoryByShopAndMonth(string shopName, string Mounth)
        {
            double sum = 0;
            foreach (var Purchase in GetAllPurchases())
            {
                Item item = GetAllItems(x => x.Id == Purchase.ItemId).FirstOrDefault();

                if (item != null && item.ShopName == shopName && Purchase.Date.ToString("MMM yy") == Mounth)
                    sum += int.Parse(Purchase.Count) * item.Price;
            }
            return sum;
        }

        // get total purchases price of specific item
        public IEnumerable<double> GetHistoryByItem(string itemName, string[] Months)
        {
            double[] values = new double[Months.Length];
            for (int i = 0; i < Months.Length; i++)
            {
                values[i] = GetHistoryByItemAndMonth(itemName, Months[i]);
            }
            return values;
        }

        // get one month's total purchases price of specific item
        private double GetHistoryByItemAndMonth(string itemName, string Month)
        {
            double count = 0;
            foreach (var Purchase in GetAllPurchases())
            {
                // find the item in items list
                Item item = GetAllItems(x => x.Id == Purchase.ItemId).FirstOrDefault();

                if (item != null && item.Name == itemName && Purchase.Date.ToString("MMM yy") == Month)
                    count += double.Parse(Purchase.Count);
            }
            return count;
        }

        // get total items purchases price of the user (ever)
        public IEnumerable<double> GetHistoryByCart(string[] Months)
        {
            double[] values = new double[Months.Length];
            for (int i = 0; i < Months.Length; i++)
            {
                values[i] = GetHistoryByCartMonth(Months[i]);
            }
            return values;
        }

        // get one month's total purchases price of all items
        private double GetHistoryByCartMonth(string Month)
        {
            double sum = 0;
            foreach (var Purchase in GetAllPurchases())
            {
                Item item = GetAllItems(x => x.Id == Purchase.ItemId).FirstOrDefault();
                if (item != null && Purchase.Date.ToString("MMM yy") == Month)
                    sum += double.Parse(Purchase.Count) * item.Price;
            }
            return sum;
        }

        // generate new PurchaseId to add
        private string FindNextPurchaseId()
        {
            var AllPurchases = GetAllPurchasesOfAllUsers();
            if (AllPurchases == null || AllPurchases.Count == 0)
                return "1";
            return (AllPurchases
                   .Select(item => int.Parse(item.Id)).Max() + 1).ToString();
        }

        //Getters
        #region Getters
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
        #endregion

        // Analyzing

        // get all prices for all items
        public IEnumerable<string> GetPriceComparison(string ItemName)
        {
            List<string> PriceComparison = new List<string>();

            foreach (var item in dal.GetAllItems(item => item.Name == ItemName))
            {
                PriceComparison.Add(item.ShopName + " " + item.BranchName + "\n" + item.Price.ToString("C"));
            }
            return PriceComparison;
        }

        public double GetCartPriceByShopName(string ShopName, IEnumerable<string> itemsNames)
        {
            double sum = 0;
            List<Item> Items = GetAllItems(item => item.ShopName + " " + item.BranchName == ShopName && itemsNames.Contains(item.Name));
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


        // Recommendations Algorithm
        /*
        public Dictionary<string, List<string>> AnalyzeHistory(List<string> itemsNames)
        {
            if (itemsNames == null || itemsNames.Count == 0)
                return null;
            Dictionary<string, Dictionary<string, int>> analyzeDict = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, List<string>> itemsInDate = new Dictionary<string, List<string>>();
            List<PurchaseItem> Purchases = GetAllPurchases();

            // itemsInDate Dict = { Date : List_of_items_bought }
            foreach (var purchase in Purchases)
            {
                string dateOfPurchase = purchase.Date.ToString("dd.MM.yyyy");
                if (!itemsInDate.Keys.Contains(dateOfPurchase))
                    itemsInDate.Add(dateOfPurchase, new List<string> { GetItemNameById(purchase.ItemId) });
                else if (!itemsInDate[dateOfPurchase].Contains(GetItemNameById(purchase.ItemId)))
                    itemsInDate[dateOfPurchase].Add(GetItemNameById(purchase.ItemId));
            }


            // analyzeDict = { itemName : connection_counter }
            foreach (var item in itemsNames)
            {
                Dictionary<string, int> connectionCounter = new Dictionary<string, int>();
                foreach (var itemsOfDate in itemsInDate)
                {
                    if (itemsOfDate.Value.Contains(item))
                    {
                        foreach (var tempItem in itemsOfDate.Value)
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
                analyzeDict.Add(item, connectionCounter);
            }
            // connectionCounter Dict = { itemName : how_many_times_it_was_bought_with_an_item_from_this_purchase }
            // {1} : 3
            // {2} : 5
            // {3} : 2
            // {4} : 1

            // allConnectionCounter dict = {

            Dictionary<string, int> allConnectionCounter = new Dictionary<string, int>();
            // go over each item in counter dictionary
            foreach (var itemAnalyze in analyzeDict.Values)
            {
                foreach (var itemCounter in itemAnalyze)
                {
                    if (!itemsNames.Contains(itemCounter.Key))
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

            // order the suggested items (that go well with the cart items) by freq of appearing together
            var sortedAllConnectionCounter = allConnectionCounter.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> suggestedItems = new List<string>();

            // add top 3 suggested items to new list (suggestedItems)
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

                    foreach (var analyzedItem in analyzeDict)
                    {
                        if (analyzedItem.Value.Keys.Contains(suggestedItem))
                        {
                            if (analyzedItem.Value[suggestedItem] > maxValueConnector)
                            {
                                maxConnector = analyzedItem.Key;
                                maxValueConnector = analyzedItem.Value[suggestedItem];
                            }
                            if (analyzedItem.Value[suggestedItem] > maxValueConnector2 && maxConnector != analyzedItem.Key)
                            {
                                maxConnector2 = analyzedItem.Key;
                                maxValueConnector2 = analyzedItem.Value[suggestedItem];
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
        */

        public Dictionary<string, List<string>> AnalyzeHistory(List<string> itemsNames)
        {
            Dictionary<string, int> countPerItem = new Dictionary<string, int>();
            List<PurchaseItem> Purchases = GetAllPurchases();
            Dictionary<string, List<string>> itemsPerDate = new Dictionary<string, List<string>>();

            //Creates Carts
            foreach ( var PurchaseItem in Purchases)
            {
                string dateOfPurchase = PurchaseItem.Date.ToString("dd.MM.yyyy");
                if(!itemsPerDate.Keys.Contains(dateOfPurchase))
                {
                    itemsPerDate[dateOfPurchase] = new List<string>();
                }
                itemsPerDate[dateOfPurchase].Add(GetItemNameById(PurchaseItem.ItemId));
            }

            //Delete the irrelevant
            List<string> toRemove = new List<string>();
            foreach (var Cart in itemsPerDate.Values)
            {
                if(!Cart.Intersect(itemsNames).Any())
                {
                    var key = itemsPerDate.Where(pair => pair.Value.Equals(Cart))
                     .Select(pair => pair.Key)
                     .FirstOrDefault();
                    toRemove.Add(key);
                }
            }
            foreach(var removeItem in toRemove)
            {
                itemsPerDate.Remove(removeItem);
            }

            //Choos the most relevant items from the relevant cars
            Dictionary<string, int> CountItems = new Dictionary<string, int>();
            foreach(var Cart in itemsPerDate.Values)
            {
                foreach(var item in Cart)
                {
                    if(!itemsNames.Contains(item))
                    {
                        if (!CountItems.Keys.Contains(item))
                        {
                            CountItems[item] = 0;
                        }
                        CountItems[item]++;
                    }
                }
            }
            var SortedCountItems = CountItems.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> MostRelevant = new List<string>();
            if (SortedCountItems.Count>3)
            {
                for(int i=0; i<3; i++)
                {
                    MostRelevant.Add(SortedCountItems.Last().Key);
                    SortedCountItems.Remove(SortedCountItems.Last().Key);
                }
            }
            else
            {
                for (int i = 0; i < SortedCountItems.Count; i++)
                {
                    MostRelevant.Add(SortedCountItems.Last().Key);
                    SortedCountItems.Remove(SortedCountItems.Last().Key);
                }
            }
            //Make suggestions
            Dictionary<string, List<string>> suggestions = new Dictionary<string, List<string>>();
            foreach(var Item in itemsNames)
            {
                foreach (var relevant in MostRelevant)
                {
                    foreach (var Cart in itemsPerDate.Values)
                    {
                        if (Cart.Contains(Item) && Cart.Contains(relevant) && Item!=relevant && !itemsNames.Contains(relevant))
                        {
                            if(!suggestions.Keys.Contains(Item))
                            {
                                suggestions[Item] = new List<string>();
                            }
                            suggestions[Item].Add(relevant);
                        }
                    }
                
                }
            }
            return suggestions;

        }

        public Item GetItemByQR(string Path)
        {
            string ItemId = dal.AnalyseQRCode(Path);

            if (ItemId != null && GetAllItems().Select(item => item.Id).ToList().Contains(ItemId))
            {
                return GetAllItems().Where(item => item.Id == ItemId).FirstOrDefault();
            }
            return null;
        }

    }
}

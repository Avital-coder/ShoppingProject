using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class CreateCartViewModel : BaseViewModel
    {
        private CartCreationModel CreatCartM { get; set; }
        #region ctor
        public CreateCartViewModel()
        {
            CreatCartM = new CartCreationModel();
            ItemList = new ObservableCollection<CartItem>();
            foreach (var item in CreatCartM.GetItems())
            {
                ItemList.Add(new CartItem() { Name = item });
            }

            CartItemList = new ObservableCollection<CartItem>();

            CartViewItem = new ObservableCollection<CartItem>();

            OfferViewItem = new ObservableCollection<CartItem>();

            ViewVisible = Visibility.Hidden;
        }
        #endregion
        #region collections
        public ObservableCollection<CartItem> ItemList { get; set; }
        public ObservableCollection<CartItem> CartItemList { get; set; }
        public ObservableCollection<CartItem> CartViewItem { get; set; }
        public ObservableCollection<CartItem> OfferViewItem { get; set; }
        #endregion
        #region inner class
        public class CartItem : BaseViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Count { get; set; }
            public string ImagePath { get; set; }
            public string CheapestBranch { get; set; }
            private bool isChecked;
            public bool IsChecked
            {
                get { return isChecked; }
                set
                {

                    isChecked = value;
                    OnPropertyRaised("IsChecked");
                }
            }
        }
        #endregion
        #region commands
        public ICommand UpdateListCommand
        {
            get
            {
                return new UpdateListCreateCardCommand(this);
            }
        }
        public ICommand UpdateOfferCommand
        {
            get
            {
                return new UpdateOfferCreateCardCommand(this);
            }
        }
        public ICommand CloseViewCommand
        {
            get
            {
                return new BaseCommand(delegate () { this.ViewVisible = Visibility.Hidden; });
            }
        }
        public ICommand CreatePdf
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    List<object[]> items = new List<object[]>();
                    foreach (CartItem item in CartItemList)
                    {
                        items.Add(new object[] { item.Name, item.Description, item.Count, item.CheapestBranch });
                    }
                    CreatCartM.CreatePDF(items);
                });
            }
        }
        #endregion
        #region view property
        private Visibility viewVisible;
        public Visibility ViewVisible
        {
            get { return viewVisible; }
            set
            {

                viewVisible = value;
                OnPropertyRaised("ViewVisible");
            }
        }
        #endregion
        #region update funcs
        public void UpdatePriceCartList(string itemName)
        {
            foreach (var tempItem in CartItemList)
            {
                if (tempItem.Name == itemName)
                {
                    CartItemList.Remove(tempItem);
                    tempItem.IsChecked = false;
                    if (viewVisible == Visibility.Visible)
                        BuyingOffer();
                    return;
                }
            }

            foreach (var tempItem in ItemList)
            {
                if (tempItem.Name == itemName)
                {
                    Item item = CreatCartM.GetItemsByName(itemName).FirstOrDefault();
                    tempItem.Description = item.Description;
                    tempItem.ImagePath = item.ImagePath;
                    tempItem.CheapestBranch = CreatCartM.GetCheapestBranchPerItem(itemName);
                    tempItem.IsChecked = true;
                    CartItemList.Add(tempItem);
                    BuyingOffer();
                }
            }
        }


        public void UpdateOfferCartList(string itemName)
        {
            foreach (var tempItem in CartItemList)
            {
                if (tempItem.Name == itemName)
                {
                    return;
                }
            }

            foreach (var tempItem in ItemList)
            {
                if (tempItem.Name == itemName)
                {
                    Item item = CreatCartM.GetItemsByName(itemName).FirstOrDefault();
                    tempItem.Description = item.Description;
                    tempItem.ImagePath = item.ImagePath;
                    tempItem.CheapestBranch = CreatCartM.GetCheapestBranchPerItem(itemName);
                    tempItem.IsChecked = true;
                    CartItemList.Add(tempItem);
                }
            }
        }
        #endregion
        #region other
        public void BuyingOffer()
        {
            CartViewItem.Clear();
            OfferViewItem.Clear();
            Dictionary<string, List<string>> BuyingOffer = CreatCartM.GetBuyingOffer(CartItemList.Select(x => x.Name).ToList());

            if (BuyingOffer != null && BuyingOffer.Count != 0)
            {
                foreach (var tempItemName in BuyingOffer.Keys)
                {
                    foreach (var tempCartItem in CartItemList)
                    {
                        if (tempItemName == tempCartItem.Name)
                            CartViewItem.Add(tempCartItem);
                    }
                }

                List<string> tempItemList = new List<string>();

                foreach (var list in BuyingOffer.Values)
                {
                    tempItemList.AddRange(list);
                }

                foreach (var tempItemName in tempItemList.Distinct())
                {

                    foreach (var tempItem in ItemList)
                    {
                        if (tempItem.Name == tempItemName)
                        {
                            Item item = CreatCartM.GetItemsByName(tempItemName).FirstOrDefault();
                            tempItem.Description = item.Description;
                            tempItem.ImagePath = item.ImagePath;
                            tempItem.CheapestBranch = CreatCartM.GetCheapestBranchPerItem(tempItemName);
                            OfferViewItem.Add(tempItem);
                        }
                    }

                }

                ViewVisible = Visibility.Visible;
                return;
            }
            ViewVisible = Visibility.Hidden;
        }
        #endregion
    }
}

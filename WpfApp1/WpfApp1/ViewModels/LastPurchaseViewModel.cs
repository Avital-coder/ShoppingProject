
using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class LastPurchaseViewModel : BaseViewModel
    {
        public LastPurchaseViewModel()
        {
            LastPurchaseM = new LastPurchaseModel();
            ListBranchs = new ObservableCollection<string>();
            PurchaseItems = new ObservableCollection<PurchaseItem>(LastPurchaseM.GetPurchaseItems());
            Items = new List<string>(LastPurchaseM.GetItemsNamesList().OrderBy(x => x));
            ShowAddGrid = Visibility.Hidden;
        }
        #region collection
        public ObservableCollection<PurchaseItem> PurchaseItems { get; set; }
        #endregion
        #region commands property
        public ICommand ConfirmedItemCommand
        {
            get
            {
                return new ConfirmedItemCommand(this);
            }
        }

        public ICommand AddPurchaseItemCommand
        {
            get
            {
                return new AddPurchaseItemCommand(this);
            }
        }
        public ICommand DeleteItemCommand
        {
            get
            {
                return new DeleteItemCommand(this);
            }
        }

        public ICommand ShowAddGridCommand
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ShowAddGrid = Visibility.Visible;
                });
            }
        }
        public ICommand HideAddGridCommand
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ShowAddGrid = Visibility.Hidden;
                });
            }
        }

        public ICommand ConfirmedAllItemCommand
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ObservableCollection<PurchaseItem> TempPurchaseItems = new ObservableCollection<PurchaseItem>(PurchaseItems);

                    foreach (PurchaseItem PurchaseItem in TempPurchaseItems)
                    {
                        string count = PurchaseItem.Count;
                        if (count != null && count.All((char c) => char.IsDigit(c)) && int.Parse(count) >= 0)
                            AddPurchase(PurchaseItem);
                    }

                });
            }
        }

        #endregion
        #region view property

        private Visibility showAddGrid;
        public Visibility ShowAddGrid
        {
            get { return showAddGrid; }
            set
            {

                showAddGrid = value;
                OnPropertyRaised("ShowAddGrid");
            }
        }

        private string comboboxItemContent { get; set; }
        public string ComboboxItemContent
        {
            get { return comboboxItemContent; }
            set
            {

                comboboxItemContent = value;
                OnPropertyRaised("ComboboxItemContent");
                ListBranchs.Clear();
                foreach (string item in LastPurchaseM.GetBranchsList(value))
                {
                    ListBranchs.Add(item);
                }
            }
        }


        private string comboboxShopContent { get; set; }
        public string ComboboxShopContent
        {
            get { return comboboxShopContent; }
            set
            {

                comboboxShopContent = value;
                OnPropertyRaised("ComboboxShopContent");
                PurchaseItem TempPurchaseItem = new PurchaseItem();
                TempPurchaseItem.Date = DateTime.Now;
                if (value != null)
                    TempPurchaseItem.ItemId = LastPurchaseM.GetItem(x => (x.ShopName + " " + x.BranchName) == comboboxShopContent && x.Name == comboboxItemContent).Id;
                AddPurchaseItem = TempPurchaseItem;
            }
        }

        public ObservableCollection<string> ListBranchs { get; set; }

        public List<string> Items { get; set; }

        #endregion
        #region properties
        public LastPurchaseM LastPurchaseM { get; set; }

        public PurchaseItem addPurchaseItem { get; set; }

        public PurchaseItem AddPurchaseItem
        {
            get { return addPurchaseItem; }
            set
            {

                addPurchaseItem = value;
                OnPropertyRaised("AddPurchaseItem");
            }
        }
        #endregion       
        #region other
        public void DeletePurchase(PurchaseItem PurchaseItem)
        {
            PurchaseItems.Remove(PurchaseItem);
            LastPurchaseM.DeletePurchaseFromUserFile(PurchaseItem);
        }

        public void AddPurchase(PurchaseItem PurchaseItem)
        {
            if (LastPurchaseM.AddPurchase(PurchaseItem))
                PurchaseItems.Remove(PurchaseItem);
        }
        #endregion
    }

}

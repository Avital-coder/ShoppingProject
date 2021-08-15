using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public BaseViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #region commands
        
        public ICommand DisplayContactUsView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new ContactViewModel(); });
            }
        }
        
        /*
        public ICommand DisplayAboutUsView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new AboutUsViewModel(); });
            }
        }*/

        public ICommand DisplayLoginView
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    
                    ((App)Application.Current).Currents.CurrentViewModel = new LoginViewModel();
                   /* ((App)Application.Current).Currents.GoBack.Clear();*/
                    ((App)Application.Current).Currents.CurrentUser = null;
                });
            }
        }
        
        /*
        public ICommand GoBack
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = ((App)Application.Current).Currents.GoBack.Pop(); ((App)Application.Current).Currents.GoBack.Pop(); }, () => ((App)Application.Current).Currents.GoBack.Count() > 0);
            }
        }*/

        public ICommand Logout
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    
                    ((App)Application.Current).Currents.CurrentViewModel = new LoginViewModel();
                    //((App)Application.Current).Currents.GoBack.Clear();
                    ((App)Application.Current).Currents.CurrentUser = null;
                });
            }
        }
        
        public ICommand LastPurchase
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new LastPurchaseViewModel(); });
            }
        }

        public ICommand HistoryByShop
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new HistoryByShopViewModel(); });
            }
        }
        public ICommand HistoryByItem
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new HistoryByItemViewModel(); });
            }
        }

        public ICommand HistoryBySCart
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new HistoryBySCartViewModel(); });
            }
        }

        public ICommand PriceComparison
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new PriceComparisonViewModel(); });
            }
        }

        public ICommand CreateCart
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new CreateCartViewModel(); });
            }
        }
        
        #endregion

    }
}

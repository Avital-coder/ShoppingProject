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
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new ContactVM(); });
            }
        }
        public ICommand DisplayAboutUsView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new AboutUsVM(); });
            }
        }

        public ICommand DisplayLoginView
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ((App)Application.Current).Currents.CurrentVM = new LoginVM();
                    ((App)Application.Current).Currents.GoBack.Clear();
                    ((App)Application.Current).Currents.LoggedUser = null;
                });
            }
        }
        public ICommand GoBack
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = ((App)Application.Current).Currents.GoBack.Pop(); ((App)Application.Current).Currents.GoBack.Pop(); }, () => ((App)Application.Current).Currents.GoBack.Count() > 0);
            }
        }

        public ICommand Logout
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ((App)Application.Current).Currents.CurrentVM = new LogInViewModel();
                    ((App)Application.Current).Currents.GoBack.Clear();
                    ((App)Application.Current).Currents.LoggedUser = null;
                });
            }
        }
        public ICommand LastPurchase
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new LastPurchaseViewModel(); });
            }
        }

        public ICommand HistoryByShop
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryByShopViewModel(); });
            }
        }
        public ICommand HistoryByItem
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryByItemViewModel(); });
            }
        }

        public ICommand HistoryBySCart
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryBySCartViewModel(); });
            }
        }

        public ICommand PriceComparison
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new PriceComparisonViewModel(); });
            }
        }

        public ICommand CreateCart
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new CreateCartViewModel(); });
            }
        }
        #endregion

    }
}

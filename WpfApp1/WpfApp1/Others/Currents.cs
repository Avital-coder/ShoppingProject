using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;

namespace WpfApp1.Others
{


    /// <summary>
    /// class for keeping current application-wide properties
    /// </summary>

    public class Currents : INotifyPropertyChanged
    {
        
       //public Stack<BaseViewModel> GoBack;
       public Currents()
       {
           //GoBack = new Stack<BaseViewModel>();
       }

       private BaseViewModel currentViewModel;
       public BaseViewModel CurrentViewModel
       {
           get { return currentViewModel; }
           set
           {
               //if (currentVM != null && !currentVM.GetType().Equals(value.GetType()))
                  // GoBack.Push(currentVM);
               currentViewModel = value;
               OnPropertyRaised("CurrentViewModel");

           }
       }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyRaised("CurrentUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}

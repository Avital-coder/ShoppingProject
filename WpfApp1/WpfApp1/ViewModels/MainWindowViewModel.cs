using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;
using System.Windows;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            ((App)Application.Current).Currents.CurrentViewModel = new LoginViewModel();
        }
    }
}

using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    public class UpdateGraphCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string shopName = parameter as string;
            CurrentVM.updateGraph(shopName);
            ((App)Application.Current).Currents.CurrentViewModel = CurrentVM;
        }
        public HistoryByShopViewModel CurrentVM { get; set; }

        public UpdateGraphCommand(HistoryByShopViewModel VM)
        {
            CurrentVM = VM;
        }
    }
}

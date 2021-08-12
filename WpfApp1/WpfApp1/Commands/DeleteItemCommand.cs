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
    class DeleteItemCommand : ICommand
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
            PurchaseItem Item = parameter as PurchaseItem;
            CurrentVM.DeletePurchase(Item);
            ((App)Application.Current).Currents.CurrentViewModel = CurrentVM;
        }

        public LastPurchaseViewModel CurrentVM { get; set; }

        public DeleteItemCommand(LastPurchaseViewModel VM)
        {
            CurrentVM = VM;
        }
    }
}

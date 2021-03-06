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
    class ConfirmedItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                PurchaseItem Item = parameter as PurchaseItem;
                string count = Item.Count;
                if (!string.IsNullOrEmpty(count) && count.All((char c) => char.IsDigit(c)) && int.Parse(count) >= 0)
                    return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            PurchaseItem Item = parameter as PurchaseItem;
            CurrentVM.AddPurchase(Item);
            ((App)Application.Current).Currents.CurrentViewModel = CurrentVM;
        }

        public LastPurchaseViewModel CurrentVM { get; set; }

        public ConfirmedItemCommand(LastPurchaseViewModel VM)
        {
            CurrentVM = VM;
        }
    }
}

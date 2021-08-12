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
    class UpdatePriceComparisonListCommand : ICommand
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
            string itemName = parameter as string;
            CurrentVM.UpdatericeComparisonList(itemName);
            ((App)Application.Current).Currents.CurrentViewModel = CurrentVM;
        }
        public PriceComparisonViewModel CurrentVM { get; set; }

        public UpdatePriceComparisonListCommand(PriceComparisonViewModel VM)
        {
            CurrentVM = VM;
        }
    }
}

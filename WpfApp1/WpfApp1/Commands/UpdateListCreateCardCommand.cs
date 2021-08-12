﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    class UpdateListCreateCardCommand : ICommand
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
            CurrentVM.UpdatePriceCartList(itemName);
            ((App)Application.Current).Currents.CurrentViewModel = CurrentVM;
        }
        public CreateCartViewModel CurrentVM { get; set; }

        public UpdateListCreateCardCommand(CreateCartViewModel VM)
        {
            CurrentVM = VM;
        }
    }
}

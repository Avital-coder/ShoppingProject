using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    class SignUpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SignUpViewModel CurrentVM { get; set; }

        public SignUpCommand(SignUpViewModel VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            PasswordBox PasswordBox1 = values[0] as PasswordBox;
            PasswordBox PasswordBox2 = values[1] as PasswordBox;
            CurrentVM.Password1 = PasswordBox1.Password;
            CurrentVM.Password2 = PasswordBox2.Password;
            CurrentVM.Signup();
        }
    }
}

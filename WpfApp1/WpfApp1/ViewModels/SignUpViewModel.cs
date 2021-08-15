using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using BE;
using System.ComponentModel;
using WpfApp1.Others;
using WpfApp1.Validations;

namespace WpfApp1.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public SignUpModel SignUpModel { get; set; }
        public SignUpViewModel()
        {
            ErrorMessageVisible = Visibility.Hidden;
            SuccessMessageVisible = Visibility.Hidden;
            SignUpModel = new SignUpModel();
        }
        #region command properties

        public ICommand SignUpCommand
        {
            get
            {
                return new SignUpCommand(this);
            }
        }

        public ICommand ErrorCommand
        {
            get
            {
                return new BaseCommand(delegate () { this.clear(); });
            }
        }
        public ICommand SuccessCommand
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentViewModel = new LoginViewModel(); /*((App)Application.Current).Currents.GoBack.Clear(); */});
            }
        }
        #endregion
        #region signup properties

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyRaised("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {

                lastName = value;
                OnPropertyRaised("LastName");
            }
        }

        public string id;

        public string Id
        {
            get { return id; }
            set
            {

                id = value;
                OnPropertyRaised("Id");
            }
        }


        private string mail;
        public string Mail
        {
            get { return mail; }
            set
            {

                mail = value;
                OnPropertyRaised("Mail");
            }
        }

        private string password1;
        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = null;
                Password2 = null;
                password1 = value;
                OnPropertyRaised("Password1");
                OnPropertyRaised("Password2");
            }
        }

        private string password2;
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = null;
                password2 = value;
                OnPropertyRaised("Password2");
            }
        }
        #endregion
        #region view properties

        private string messageText;
        public string MassageText
        {
            get { return messageText; }
            set
            {
                messageText = value;
                OnPropertyRaised("MassageText");
            }
        }

        private Visibility errorMessageVisible;
        public Visibility ErrorMessageVisible
        {
            get { return errorMessageVisible; }
            set
            {

                errorMessageVisible = value;
                OnPropertyRaised("ErrorMessageVisible");
            }
        }

        private Visibility successMessageVisible;
        public Visibility SuccessMessageVisible
        {
            get { return successMessageVisible; }
            set
            {

                successMessageVisible = value;
                OnPropertyRaised("SuccessMessageVisible");
            }
        }

        #endregion
        #region other
        public void Signup()
        {


            if (FirstName == null || LastName == null || Id == null || Mail == null || Password1 == null)
            {
                MassageText = "make sure everything is filled";
                ErrorMessageVisible = Visibility.Visible;
            }


            else if (!new ValidPassword().IsValidPassword(Password1))
            {
                MassageText = "your password is too weak";
                ErrorMessageVisible = Visibility.Visible;
            }


            else
            {
                User user = new User(FirstName, LastName, Id, Mail, Password1);
                if (SignUpModel.Signup(user))
                    SuccessMessageVisible = Visibility.Visible;
                else
                {
                    MassageText = "oops, we already know you";
                    ErrorMessageVisible = Visibility.Visible;
                }

            }


        }
        public void clear()
        {
            ErrorMessageVisible = Visibility.Hidden;
        }
        #endregion
    }
}

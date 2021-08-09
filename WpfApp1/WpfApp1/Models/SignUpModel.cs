using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using BL;

namespace WpfApp1.Models
{
    class SignUpModel
    {

        public IBL BL { get; set; }

        public SignUpModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }


        public bool Signup(User user)
        {
            return BL.AddUser(user);
        }
    }
}

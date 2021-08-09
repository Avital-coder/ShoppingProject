using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using System.Windows;

namespace WpfApp1.Models
{
    class LogInModel
    {
        IBL BL;
        public LogInModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.currentUser);
        }

        public bool Login(string Mail, string Password)
        {
            User user = BL.GetAllUsers(tempUser => tempUser.Mail == Mail && tempUser.Password == Password).FirstOrDefault();
            if (user != null)
            {
                ((App)Application.Current).Currents.currentUser = user;
                return true;
            }
            return false;
        }
    }
}

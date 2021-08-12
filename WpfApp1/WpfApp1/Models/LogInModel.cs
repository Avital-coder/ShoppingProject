﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using System.Windows;

namespace WpfApp1.Models
{
    class LoginModel
    {
        IBL BL;
        public LoginModel()
        {
            BL = new BLImp(((App)Application.Current).Currents.CurrentUser);
        }

        public bool Login(string Mail, string Password)
        {
            User user = BL.GetAllUsers(tempUser => tempUser.Mail == Mail && tempUser.Password == Password).FirstOrDefault();
            if (user != null)
            {
                ((App)Application.Current).Currents.CurrentUser = user;
                return true;
            }
            return false;
        }
    }
}

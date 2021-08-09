using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public User(string FirstName, string LastName, string Id, string Mail, string password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
            this.Mail = Mail;
            this.Password = password;
        }

        public User()
        { }
    }
}
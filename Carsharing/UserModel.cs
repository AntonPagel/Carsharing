using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public UserModel()
        {

        }

        public bool Check(string username, string password)
        {
            return username.Equals(Username) && password.Equals(Password);
        }
    }
}
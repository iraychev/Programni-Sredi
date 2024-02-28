using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    internal class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }
        public string Names
        {
            get { return _user.Names; }
            set { _user.Names = value;  }
        }

        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }

        public userRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }
    }
}

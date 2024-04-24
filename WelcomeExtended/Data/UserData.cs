using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user) 
        { 
            user.ID = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(User user) 
        { 
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password) 
        { 
            foreach (var user in _users) 
            { 
                if(user.Name == name && user.Password == password) 
                    return true;
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(u => u.Name == name && u.Password == password)
                         .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var res = from user in _users
                      where user.Name == name && user.Password == password
                      select user.ID;
            return res != null ? true: false;
        }

        public User GetUser(string name, string password)
        {
            return _users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public void SetActive(string name, DateTime expires)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Expires = expires;
            }
        }
        public void AssignUserRole(string name, UserRolesEnums role)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}

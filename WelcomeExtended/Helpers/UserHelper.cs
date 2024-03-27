using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static void ToString (this User user)
        {
            user.ToString ();
        }

        public static void ValidateUser (this User user, string name, string password)
        {
            if (user == null || name == null || password == null)
            {
                throw new Exception($"The field cannot be empty");
            }

            user.ValidateUser (name, password);
        }
        public static void GetUser(this User user, string name, string password)
        {
            user.GetUser(name, password);
        }
    }
}

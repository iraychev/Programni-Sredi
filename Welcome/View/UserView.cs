using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {

            Console.WriteLine($"Welcome! \nUser: {_viewModel.Name} \nRole: {_viewModel.Role}");

        }

        public void DisplayErr()
        {
            throw new Exception("Error message");

        }
    }
}

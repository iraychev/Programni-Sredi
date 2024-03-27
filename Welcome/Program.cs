using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            user.Name = "🍌Ceci Meci🍌";
            user.Password = "12345";
            user.Role = Others.UserRolesEnums.STUDENT;
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            Console.ReadKey();
        }
    }
}

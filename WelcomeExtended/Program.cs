using System.Data;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;
using static WelcomeExtended.Others.Delegates;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var user = new User
                {
                    Names = "Ivo Raychev",
                    Role = Others.userRolesEnum.STUDENT,
                    Password = "parola"
                };
                
                UserViewModel userViewModel = new UserViewModel(user);

                UserView userView = new UserView(userViewModel);

                userView.Display();

                userView.DisplayErr();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Log);
                log(e.Message); 
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
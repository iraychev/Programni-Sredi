using System.Data;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;
using static WelcomeExtended.Others.Delegates;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
			
				UserData userData = new UserData();

				User student = new User()
				{
					Name = "🍌Ceci Meci🍌",
					Password = "password",
					Role = Welcome.Others.UserRolesEnums.STUDENT
				};
				userData.AddUser(student);
			}
			catch (Exception e)
			{
				var log = new ActionOnError(Log);
				log(e.Message);
			}
			finally
			{
				Console.WriteLine("Executed in any case");
			}
        }
    }
}

using System.Data;
using Welcome.Model;
using Welcome.View;
using Welcome.Others;
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
            UserData userData = new UserData();
            LoginLogger loginLogger = new LoginLogger();

            try
            {
                createUsers(userData);
                loginUser(userData, loginLogger);
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

        public static void createUsers(UserData userData)
        {
            User student = new User()
            {
                Name = "Ceci Meci",
                Password = "password",
                Role = UserRolesEnums.STUDENT
            };
            userData.AddUser(student);

            User student2 = new User()
            {
                Name = "Student 2",
                Password = "123",
                Role = UserRolesEnums.STUDENT
            };
            userData.AddUser(student2);

            User teacher = new User()
            {
                Name = "Teacher",
                Password = "1234",
                Role = UserRolesEnums.PROFESSOR
            };
            userData.AddUser(teacher);

            User admin = new User()
            {
                Name = "Admin",
                Password = "12345",
                Role = UserRolesEnums.ADMIN
            };
            userData.AddUser(admin);
        }

        public static void loginUser(UserData userData, LoginLogger loginLogger)
        {
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            if (userData.ValidateUser(username, password))
            {

                loginLogger.LogSuccess(username);
                Console.WriteLine($"{username} has logged in successfully.");

                User loggedInUser = userData.GetUser(username, password);
                Console.WriteLine(loggedInUser.ToString()); // Assuming User has a ToString override
            }
            else
            {
                loginLogger.LogError(username, "Invalid username or password.");
                Console.WriteLine("Invalid username or password.");
            }
        }
    }
}

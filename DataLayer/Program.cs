using DataLayer.Database;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnums.STUDENT
                });
                context.SaveChanges();
                var users = context.Users.ToList();
                Console.ReadKey();
            }
        }
    }
}
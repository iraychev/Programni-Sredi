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

                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Get all users");
                    Console.WriteLine("2. Add a user");
                    Console.WriteLine("3. Delete a user");
                    Console.WriteLine("4. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Get all users
                            var users = context.Users.ToList();
                            foreach (var user in users)
                            {
                                Console.WriteLine($"ID: {user.ID}, Name: {user.Name}, Role: {user.Role}");
                            }
                            break;
                        case "2":
                            // Add a user
                            Console.WriteLine("Enter username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter password:");
                            string password = Console.ReadLine();
                            Console.WriteLine("Enter email:");
                            string email = Console.ReadLine();

                            context.Add<DatabaseUser>(new DatabaseUser()
                            {
                                Name = username,
                                Password = password,
                                Expires = DateTime.Now,
                                Role = UserRolesEnums.STUDENT,
                                Email = email,
                                FacultyNumber = "155"
                            });
                            context.LogEntries.Add(new LogEntry
                            {
                                Timestamp = DateTime.Now,
                                Message = "User added: " + username
                            });
                            context.SaveChanges();
                            Console.WriteLine("User added successfully.");
                            break;
                        case "3":
                            // Delete a user
                            Console.WriteLine("Enter the name of the user to delete:");
                            string nameToDelete = Console.ReadLine();
                            var userToDelete = context.Users.FirstOrDefault(u => u.Name == nameToDelete);
                            if (userToDelete != null)
                            {
                                context.Users.Remove(userToDelete);
                                context.LogEntries.Add(new LogEntry
                                {
                                    Timestamp = DateTime.Now,
                                    Message = "User deleted: " + nameToDelete
                                });
                                context.SaveChanges();
                                Console.WriteLine($"User '{nameToDelete}' deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"User '{nameToDelete}' not found.");
                            }                        
                            break;
                        case "4":
                            // Exit the program
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear(); // Clear the console for the next iteration
                }
            }
        }

    }
}
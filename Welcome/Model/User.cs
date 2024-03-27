using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRolesEnums Role { get; set; }

    }
}

using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public virtual int ID { get; set; }
        public string Name { get; set; }
        public string Password {
            get;
            set;
        }
        public string Email { get; set; }
        public string FacultyNumber { get; set; }
        public UserRolesEnums Role { get; set; }
        public DateTime Expires { get; set; }

    }
}

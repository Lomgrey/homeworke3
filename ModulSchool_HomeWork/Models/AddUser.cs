namespace ModulSchool_HomeWork.Models
{
    public class AddUser : IAddUser
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
    }
}
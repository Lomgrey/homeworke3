namespace ModulSchool_HomeWork.Models
{
    public interface IAddUser
    {
        string Email { get; set; }
        string Nickname { get; set; }
        string Phone { get; set; }
    }
}
using System.Windows.Input;

namespace ModulSchool_HomeWork.Models
{
    public interface IAddUserResult
    {
        string Status { get; set; }
        string Message { get; set; }
    }
}